using Tickets.DataAccess.Repositories;
using Tickets.Tests.Common;

namespace Tickets.DataAccess.Tests.Repositories
{
    public class SectionRepositoryTests
    {

        [Fact]
        public async Task GetAsync_ShouldReturnPagedSections_ForGivenVenueId()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetAsync_ShouldReturnPagedSections_ForGivenVenueId));
            var venueId = Guid.NewGuid();

            dbContext.Sections.AddRange(Enumerable.Range(1, 8).Select(i => ModelCreationHelper.CreateSection(venueId: venueId)));
            await dbContext.SaveChangesAsync();

            var repository = new SectionRepository(dbContext);

            var result = await repository.GetAsync(venueId, pageIndex: 0, pageSize: 5);

            Assert.NotNull(result);
            Assert.Equal(5, result.Entities.Count());
            Assert.All(result.Entities, s => Assert.Equal(venueId, s.VenueId));
        }

        [Fact]
        public async Task GetSeatsAsync_ShouldReturnPagedSeats_ForGivenSectionId()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetSeatsAsync_ShouldReturnPagedSeats_ForGivenSectionId));
            var sectionId = Guid.NewGuid();
            var row = ModelCreationHelper.CreateRow(sectionId: sectionId);

            dbContext.Rows.Add(row);
            dbContext.Seats.AddRange(Enumerable.Range(1, 12).Select(i => ModelCreationHelper.CreateSeat(rowId: row.Id)));

            await dbContext.SaveChangesAsync();

            var repository = new SectionRepository(dbContext);

            var result = await repository.GetSeatsAsync(sectionId, pageIndex: 1, pageSize: 5);

            Assert.NotNull(result);
            Assert.Equal(5, result.Entities.Count());
            Assert.All(result.Entities, s => Assert.Equal(row.Id, s.RowId));
        }
    }
}
