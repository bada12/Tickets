using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tickets.DataAccess;

namespace Tickets.Migrations
{
    internal class TicketsDbContextFactory : IDesignTimeDbContextFactory<TicketsDbContext>
    {
        public TicketsDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<TicketsDbContext>();

            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TicketsDb",
                x => x.MigrationsAssembly("Tickets.Migrations"));

            return new TicketsDbContext(optionsBuilder.Options);
        }
    }
}
