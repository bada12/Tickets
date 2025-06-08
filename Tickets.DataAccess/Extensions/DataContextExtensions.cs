using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tickets.DataAccess.Repositories;
using Tickets.Domain.Interfaces;

namespace Tickets.DataAccess.Extensions
{
    public static class DataContextExtensions
    {
        public static void ConfigureTicketsDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TicketsDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("TicketsDb")));


            services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IEventRepository, EventRepository>()
                .AddScoped<IOfferRepository, OfferRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IVenueRepository, VenueRepository>()
                .AddScoped<ISeatRepository, SeatRepository>()
                .AddScoped<ISectionRepository, SectionRepository>();
        }
    }
}
