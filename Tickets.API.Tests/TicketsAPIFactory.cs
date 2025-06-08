using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Tickets.DataAccess;

namespace Tickets.API.Tests
{
    public class TicketsAPIFactory
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public TicketsAPIFactory()
        {
            string dbNumber = Guid.NewGuid().ToString().Substring(0, 8);

            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.Remove(
                            services.SingleOrDefault(d => d.ServiceType == typeof(IDbContextOptionsConfiguration<TicketsDbContext>))
                         );

                        services.AddDbContext<TicketsDbContext>(options =>
                        {
                            options.UseSqlServer(
                                $"Server=(localdb)\\mssqllocaldb;Database=TicketsTestDb-{dbNumber};Trusted_Connection=True;MultipleActiveResultSets=true");
                        });

                        var sp = services.BuildServiceProvider();

                        using var scope = sp.CreateScope();
                        var db = scope.ServiceProvider.GetRequiredService<TicketsDbContext>();

                        if (db.Database.CanConnect())
                        {
                            db.Database.EnsureDeleted();
                        }

                        db.Database.EnsureCreated();
                    });
                });

            _client = _factory.CreateClient();
        }

        public WebApplicationFactory<Program> Factory => _factory;

        public HttpClient HttpClient => _client;
    }
}
