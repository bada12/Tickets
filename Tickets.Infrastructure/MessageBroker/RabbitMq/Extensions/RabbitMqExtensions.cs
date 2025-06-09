using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tickets.Infrastructure.MessageBroker.Interfaces;
using Tickets.Infrastructure.MessageBroker.Messages;
using Tickets.Infrastructure.MessageBroker.RabbitMq.MessageConsumers;

namespace Tickets.Infrastructure.MessageBroker.RabbitMq.Extensions
{
    public static class RabbitMqExtensions
    {
        public static IServiceCollection ConfigureRabbitMq(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<RabbitMQOptions>(configuration.GetSection("RabbitMQ"));

            services.AddSingleton<IMessagePublisher, MessagePublisher>();

            services.ConfigureMessageConsumers();

            return services;
        }

        private static IServiceCollection ConfigureMessageConsumers(this IServiceCollection services)
        {
            services
                .AddHostedService<MessageConsumerHostedService<PaymentNotificationMessage>>();

            services
                .AddSingleton<IMessageConsumer<PaymentNotificationMessage>, PaymentNotificationMessageConsumer>();

            return services;
        }
    }
}
