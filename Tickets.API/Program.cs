using FluentValidation;
using System.Text.Json.Serialization;
using Tickets.API.ModelsValidators;
using Tickets.API.Options;
using Tickets.API.Services;
using Tickets.API.Services.Interfaces;
using Tickets.DataAccess.Extensions;

namespace Tickets.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.Configure<CacheOptions>(builder.Configuration.GetSection("CacheOptions"));

            builder.Services.AddMemoryCache();

            builder.Services.AddSingleton<ICacheService, CacheService>();

            builder.Services.ConfigureTicketsDbContext(builder.Configuration);

            builder.Services.AddValidatorsFromAssemblyContaining<GetCartInputValidator>(lifetime: ServiceLifetime.Singleton);

            builder.Services.AddSingleton<IValidatorService, ValidatorService>();

            builder.Services.AddResponseCaching();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
