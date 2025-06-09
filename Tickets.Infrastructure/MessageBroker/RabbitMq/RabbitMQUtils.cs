using RabbitMQ.Client;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Tickets.Infrastructure.MessageBroker.RabbitMq
{
    public static class RabbitMQUtils
    {
        static RabbitMQUtils()
        {
            SerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters =
                {
                    new JsonStringEnumConverter()
                },
            };

            BasicProperties = new BasicProperties
            {
                Persistent = true
            };
        }

        public static JsonSerializerOptions SerializerOptions { get; }

        public static BasicProperties BasicProperties { get; }
    }
}
