using Tickets.DataAccess.Repositories;
using Tickets.Tests.Common;

namespace Tickets.DataAccess.Tests.Repositories
{
    public class OfferRepositoryTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddOffer()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(CreateAsync_ShouldAddOffer));
            var repository = new OfferRepository(dbContext);

            var offer = ModelCreationHelper.CreateOffer();

            var result = await repository.CreateAsync(offer);

            Assert.NotNull(result);
            Assert.Equal(offer.Id, result.Id);
            Assert.Equal(1, dbContext.Offers.Count());
        }

        [Fact]
        public async Task GetByUserIdAsync_ShouldReturnPagedOffers()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetByUserIdAsync_ShouldReturnPagedOffers));
            var userId = Guid.NewGuid();

            dbContext.Offers.AddRange(Enumerable.Range(1, 10).Select(i => ModelCreationHelper.CreateOffer(userId: userId)));
            await dbContext.SaveChangesAsync();

            var repository = new OfferRepository(dbContext);
            var result = await repository.GetByUserIdAsync(userId, pageIndex: 0, pageSize: 5);

            Assert.Equal(5, result.Entities.Count());
        }

        [Fact]
        public async Task GetAsync_ShouldReturnOfferWithSeats()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetAsync_ShouldReturnOfferWithSeats));
            var seat = ModelCreationHelper.CreateSeat();
            var offer = ModelCreationHelper.CreateOffer();
            offer.AddSeat(seat, ModelCreationHelper.CreatePriceLevel());

            dbContext.Offers.Add(offer);

            await dbContext.SaveChangesAsync();

            var repository = new OfferRepository(dbContext);
            var result = await repository.GetAsync(offer.Id);

            Assert.NotNull(result);
            Assert.Equal(offer.Id, result.Id);
            Assert.Single(result.Seats);
            Assert.Equal(seat.Number, result.Seats.First().Number);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateOffer()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(UpdateAsync_ShouldUpdateOffer));
            var seat = ModelCreationHelper.CreateSeat();
            var offer = ModelCreationHelper.CreateOffer();
            offer.AddSeat(seat, ModelCreationHelper.CreatePriceLevel());

            dbContext.Offers.Add(offer);
            await dbContext.SaveChangesAsync();

            offer.TryToDeleteSeat(seat.Id);

            var repository = new OfferRepository(dbContext);

            var updated = await repository.UpdateAsync(offer);

            Assert.Equal(offer.Timestamp, updated.Timestamp);
            Assert.Equal(1, dbContext.Offers.Count());
        }
    }
}
