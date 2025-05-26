using Tickets.DataAccess.Repositories;
using Tickets.Domain.Exceptions;
using Tickets.Tests.Common;
using PriceLevelEnum = Tickets.Domain.Enums.PriceLevel;

namespace Tickets.DataAccess.Tests.Repositories
{
    public class SeatRepositoryTests
    {
        [Fact]
        public async Task GetAsync_ShouldReturnSeat_WhenSeatExists()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetAsync_ShouldReturnSeat_WhenSeatExists));
            var seat = ModelCreationHelper.CreateSeat();

            dbContext.Seats.Add(seat);
            await dbContext.SaveChangesAsync();

            var repository = new SeatRepository(dbContext);

            var result = await repository.GetAsync(seat.Id);

            Assert.NotNull(result);
            Assert.Equal(seat.Id, result.Id);
            Assert.Equal(seat.Number, result.Number);
        }

        [Fact]
        public async Task GetPriceLevelAsync_ShouldReturnPriceLevel_WhenExists()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetPriceLevelAsync_ShouldReturnPriceLevel_WhenExists));

            var priceLevel = PriceLevelEnum.Adult;
            var priceLevelEntity = ModelCreationHelper.CreatePriceLevel(priceLevel: priceLevel);

            dbContext.PriceLevels.Add(priceLevelEntity);
            await dbContext.SaveChangesAsync();

            var repository = new SeatRepository(dbContext);

            var result = await repository.GetPriceLevelAsync(priceLevel);

            Assert.NotNull(result);
            Assert.Equal(priceLevel, result.Level);
        }

        [Fact]
        public async Task GetAsync_ShouldThrow_WhenSeatNotFound()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetAsync_ShouldThrow_WhenSeatNotFound));
            var repository = new SeatRepository(dbContext);

            await Assert.ThrowsAsync<ObjectNotFoundException>(() =>
                repository.GetAsync(Guid.NewGuid()));
        }

        [Fact]
        public async Task GetPriceLevelAsync_ShouldThrow_WhenNotFound()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetPriceLevelAsync_ShouldThrow_WhenNotFound));
            var repository = new SeatRepository(dbContext);

            await Assert.ThrowsAsync<ObjectNotFoundException>(() =>
                repository.GetPriceLevelAsync(PriceLevelEnum.Child));
        }
    }
}
