using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Resend;

namespace Tickets.Infrastructure.Extensions
{
    public static class EmailServiceExtensions
    {
        public static IServiceCollection ConfigureEmailService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpClient<ResendClient>();

            services.Configure<ResendClientOptions>(o =>
            {
                o.ApiToken = configuration.GetValue<string>("EmailService:ApiKey")!;
            });

            services.AddTransient<IResend, ResendClient>();

            return services;
        }
    }
}
