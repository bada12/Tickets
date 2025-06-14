using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tickets.API.ModelsValidators;
using Tickets.API.Options;
using Tickets.API.Services;
using Tickets.API.Services.Interfaces;
using Tickets.DataAccess.Extensions;
using Tickets.Infrastructure.Extensions;
using Tickets.Infrastructure.MessageBroker.RabbitMq.Extensions;

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

            builder.Services.ConfigureEmailService(builder.Configuration);
            builder.Services.ConfigureRabbitMq(builder.Configuration);

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

            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

                    var result = JsonSerializer.Serialize(new
                    {
                        message = exceptionHandlerPathFeature?.Error.Message,
                        statusCode = context.Response.StatusCode
                    });

                    await context.Response.WriteAsync(result);
                });
            });

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
