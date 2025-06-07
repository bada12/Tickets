using Moq;
using Tickets.API.Controllers;
using Tickets.API.Models;
using Tickets.API.Services.Interfaces;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;
using Tickets.Tests.Common;

namespace Tickets.API.Tests.Controllers
{
    public class CartsControllerTests
    {
        private readonly Mock<IOfferRepository> _offerRepoMock = new();
        private readonly Mock<ISeatRepository> _seatRepoMock = new();
        private readonly Mock<IValidatorService> _validatorMock = new();
        private readonly Mock<ICacheService> _cacheService = new();

        private CartsController CreateController() =>
            new CartsController(
                _offerRepoMock.Object,
                _seatRepoMock.Object,
                _validatorMock.Object,
                _cacheService.Object);

        [Fact]
        public async Task GetCartAsync_ShouldReturnOffer()
        {
            // Arrange
            var offerId = Guid.NewGuid();
            var offer = new Offer(offerId, Guid.NewGuid(), DateTime.UtcNow);

            var input = new GetCartInput { CartId = offerId };

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _offerRepoMock.Setup(r => r.GetAsync(offerId)).ReturnsAsync(offer);

            var controller = CreateController();

            // Act
            var result = await controller.GetCartAsync(input);

            // Assert
            Assert.Equal(offerId, result.Id);
            _validatorMock.Verify(v => v.ValidateAsync(input), Times.Once);
            _offerRepoMock.Verify(r => r.GetAsync(offerId), Times.Once);
        }

        [Fact]
        public async Task AddSeatToCartAsync_CreatesNewOfferIfNotExists()
        {
            // Arrange
            var cartId = Guid.NewGuid();
            var eventId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var seatId = Guid.NewGuid();

            var input = new AddSeatToCartInput
            {
                CartId = cartId,
                SeatInput = new SeatInput(
                    EventId: eventId,
                    SeatId: seatId,
                    PriceLevel: Domain.Enums.PriceLevel.Adult,
                    UserId: userId)
            };

            var seat = ModelCreationHelper.CreateSeat(id: seatId);
            var priceLevel = ModelCreationHelper.CreatePriceLevel(Domain.Enums.PriceLevel.Adult);

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _offerRepoMock.Setup(r => r.GetAsync(cartId)).ReturnsAsync((Offer)null!);
            _offerRepoMock.Setup(r => r.CreateAsync(It.IsAny<Offer>())).ReturnsAsync((Offer o) => o);
            _offerRepoMock.Setup(r => r.UpdateAsync(It.IsAny<Offer>())).ReturnsAsync((Offer o) => o);

            _seatRepoMock.Setup(r => r.GetAsync(seatId)).ReturnsAsync(seat);
            _seatRepoMock.Setup(r => r.GetPriceLevelAsync(Domain.Enums.PriceLevel.Adult)).ReturnsAsync(priceLevel);

            var controller = CreateController();

            // Act
            var result = await controller.AddSeatToCartAsync(input);

            // Assert
            Assert.Equal(cartId, result.Id);
            _offerRepoMock.Verify(r => r.CreateAsync(It.IsAny<Offer>()), Times.Once);
            _offerRepoMock.Verify(r => r.UpdateAsync(It.IsAny<Offer>()), Times.Once);
        }

        [Fact]
        public async Task DeleteSeatFromCartAsync_ShouldCallTryToDeleteSeatAndUpdate()
        {
            // Arrange
            var cartId = Guid.NewGuid();
            var seatId = Guid.NewGuid();
            var offer = new Mock<Offer>(cartId, Guid.NewGuid(), DateTime.UtcNow);

            var input = new DeleteSeatFromCartInput { CartId = cartId, SeatId = seatId };

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _offerRepoMock.Setup(r => r.GetAsync(cartId)).ReturnsAsync(offer.Object);

            var controller = CreateController();

            // Act
            await controller.DeleteSeatFromCartAsync(input);

            // Assert
            _offerRepoMock.Verify(r => r.UpdateAsync(offer.Object), Times.Once);
        }

        [Fact]
        public async Task BookSeatsAsync_ShouldCallBookSeats_AndUpdate()
        {
            // Arrange
            var cartId = Guid.NewGuid();
            var offer = new Mock<Offer>(cartId, Guid.NewGuid(), DateTime.UtcNow);

            var input = new BookSeatsInput { CartId = cartId };

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _offerRepoMock.Setup(r => r.GetAsync(cartId)).ReturnsAsync(offer.Object);
            _offerRepoMock.Setup(r => r.UpdateAsync(offer.Object)).ReturnsAsync(offer.Object);

            var controller = CreateController();

            // Act
            var result = await controller.BookSeatsAsync(input);

            // Assert
            Assert.Equal(cartId, result);
            _offerRepoMock.Verify(r => r.UpdateAsync(offer.Object), Times.Once);
        }
    }
}
