using Tickets.DataAccess.Repositories;
using Tickets.Tests.Common;

namespace Tickets.DataAccess.Tests.Repositories
{
    public class VenueRepositoryTests
    {
        [Fact]
        public async Task GetAsync_ShouldReturnPagedVenues()
        {
            // Arrange
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetAsync_ShouldReturnPagedVenues));

            dbContext.Venues.AddRange(Enumerable.Range(1, 10).Select(i => ModelCreationHelper.CreateVenue()));
            await dbContext.SaveChangesAsync();

            var repository = new VenueRepository(dbContext);

            // Act
            var pagedResult = await repository.GetAsync(pageIndex: 0, pageSize: 5);

            // Assert
            Assert.NotNull(pagedResult);
            Assert.Equal(5, pagedResult.Entities.Count());
            Assert.All(pagedResult.Entities, v => Assert.NotNull(v.Address));
        }
    }
}
