using Microsoft.EntityFrameworkCore;

namespace Tickets.DataAccess.Tests
{
    public static class DbContextCreationHelper
    {
        public static TicketsDbContext CreateInMemoryDbContext(string dbName)
        {
            var options = new DbContextOptionsBuilder<TicketsDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            return new TicketsDbContext(options);
        }
    }
}
