using Tickets.Infrastructure.MessageBroker.Messages;

namespace Tickets.Infrastructure.MessageBroker.Interfaces
{
    public interface IMessageConsumer<TMessage>
        where TMessage : BaseMessage
    {
        Task RegisterOnMessageReceivingAsync(CancellationToken cancellationToken);

        Task CloseQueueAsync(CancellationToken cancellationToken);
    }
}
