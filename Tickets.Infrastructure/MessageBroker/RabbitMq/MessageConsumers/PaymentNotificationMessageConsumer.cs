using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Resend;
using System.Text;
using System.Text.Json;
using Tickets.Infrastructure.MessageBroker.Interfaces;
using Tickets.Infrastructure.MessageBroker.Messages;

namespace Tickets.Infrastructure.MessageBroker.RabbitMq.MessageConsumers
{
    internal class PaymentNotificationMessageConsumer : IMessageConsumer<PaymentNotificationMessage>
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly ILogger _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private IConnection _connection;
        private IChannel _channel;

        public PaymentNotificationMessageConsumer(
            IOptions<RabbitMQOptions> rabbitMqOptions,
            ILogger<PaymentNotificationMessageConsumer> logger,
            IServiceScopeFactory serviceScopeFactory)
        {
            ArgumentNullException.ThrowIfNull(rabbitMqOptions?.Value, nameof(rabbitMqOptions));

            _connectionFactory = new ConnectionFactory
            {
                HostName = rabbitMqOptions.Value.HostName
            };

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

            _scopeFactory = serviceScopeFactory ??
                throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public Task CloseQueueAsync(CancellationToken cancellationToken)
        {
            _channel.Dispose();
            _connection.Dispose();

            return Task.CompletedTask;
        }

        public async Task RegisterOnMessageReceivingAsync(CancellationToken cancellationToken)
        {
            _connection ??= await _connectionFactory.CreateConnectionAsync();
            _channel ??= await _connection.CreateChannelAsync();

            await _channel.QueueDeclareAsync(
                queue: RabbitMQQueues.PaymentNotificationQueue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new AsyncEventingBasicConsumer(_channel);

            consumer.ReceivedAsync += async (_, eventArgs) =>
            {
                try
                {
                    byte[] body = eventArgs.Body.ToArray();
                    string message = Encoding.UTF8.GetString(body);
                    var paymentNotification = JsonSerializer.Deserialize<PaymentNotificationMessage>(
                        message,
                        RabbitMQUtils.SerializerOptions);

                    _logger.LogInformation($"Received: {nameof(PaymentNotificationMessage)} - {message}");

                    await SendEmailMessageAsync(paymentNotification);

                    await _channel.BasicAckAsync(eventArgs.DeliveryTag, multiple: false);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing message in PaymentNotificationMessageConsumer");

                    await _channel.BasicRejectAsync(eventArgs.DeliveryTag, requeue: true);
                }
            };

            await _channel.BasicConsumeAsync(
                RabbitMQQueues.PaymentNotificationQueue,
                autoAck: false,
                consumer);
        }

        private async Task SendEmailMessageAsync(PaymentNotificationMessage paymentNotification)
        {
            var emailMessage = new EmailMessage()
            {
                From = "test@tickets.dev.test.com",
                To =
                [
                    new EmailAddress()
                    {
                        Email = paymentNotification.Email
                    }
                ],
                Subject = $"Payment {paymentNotification.Status} notification",
                HtmlBody = $"<strong>Your payment has been {paymentNotification.Status}!</strong>"
            };

            await using var scope = _scopeFactory.CreateAsyncScope();
            var resend = scope.ServiceProvider.GetRequiredService<IResend>();

            var retryPolicy = Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: attempt => TimeSpan.FromSeconds(Math.Pow(2, attempt)),
                    onRetry: (exception, timeSpan, retryCount, context) =>
                    {
                        _logger.LogWarning(exception, $"Retry {retryCount} for sending email failed. Waiting {timeSpan} before next attempt.");
                    });

            await retryPolicy.ExecuteAsync(() =>
                resend.EmailSendAsync(emailMessage)
            );
        }
    }
}
