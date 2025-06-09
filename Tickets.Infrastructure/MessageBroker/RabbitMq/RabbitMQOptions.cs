namespace Tickets.Infrastructure.MessageBroker.RabbitMq
{
    public record RabbitMQOptions
    {
        public string HostName { get; init; }
    }
}
