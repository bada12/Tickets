using Tickets.Infrastructure.MessageBroker.Messages;

namespace Tickets.Infrastructure.MessageBroker.Interfaces
{
    public interface IMessagePublisher
    {
        Task PublishMessageAsync<TMessage>(TMessage message, string queueName)
            where TMessage : BaseMessage;
    }
}
