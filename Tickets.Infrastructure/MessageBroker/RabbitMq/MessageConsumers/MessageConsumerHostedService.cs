using Microsoft.Extensions.Hosting;
using Tickets.Infrastructure.MessageBroker.Interfaces;
using Tickets.Infrastructure.MessageBroker.Messages;

namespace Tickets.Infrastructure.MessageBroker.RabbitMq.MessageConsumers
{
    public class MessageConsumerHostedService<TMessage> : IHostedService
        where TMessage : BaseMessage
    {
        private readonly IMessageConsumer<TMessage> _messageConsumer;

        public MessageConsumerHostedService(IMessageConsumer<TMessage> messageConsumer)
        {
            _messageConsumer = messageConsumer ??
                throw new ArgumentNullException(nameof(messageConsumer));
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _messageConsumer.RegisterOnMessageReceivingAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _messageConsumer.CloseQueueAsync(cancellationToken);
        }
    }
}
