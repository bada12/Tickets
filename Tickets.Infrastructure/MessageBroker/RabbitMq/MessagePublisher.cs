using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Tickets.Infrastructure.MessageBroker.Interfaces;
using Tickets.Infrastructure.MessageBroker.Messages;

namespace Tickets.Infrastructure.MessageBroker.RabbitMq
{
    internal class MessagePublisher : IMessagePublisher
    {
        private readonly ConnectionFactory _connectionFactory;

        public MessagePublisher(IOptions<RabbitMQOptions> rabbitMqOptions)
        {
            ArgumentNullException.ThrowIfNull(rabbitMqOptions?.Value, nameof(rabbitMqOptions));

            _connectionFactory = new ConnectionFactory
            {
                HostName = rabbitMqOptions.Value.HostName
            };
        }

        public async Task PublishMessageAsync<TMessage>(TMessage message, string queueName)
            where TMessage : BaseMessage
        {
            using var connection = await _connectionFactory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(
                queue: queueName,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            await channel.BasicPublishAsync(
                exchange: string.Empty,
                routingKey: queueName,
                mandatory: true,
                basicProperties: RabbitMQUtils.BasicProperties,
                body: GetEncodedMessage(message));
        }

        private static byte[] GetEncodedMessage<TMessage>(TMessage message)
            where TMessage : BaseMessage
        {
            var serializedMessage = JsonSerializer.Serialize(message, RabbitMQUtils.SerializerOptions);
            var body = Encoding.UTF8.GetBytes(serializedMessage);

            return body;
        }
    }
}
