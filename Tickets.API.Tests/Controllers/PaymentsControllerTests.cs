using Moq;
using Tickets.API.Controllers;
using Tickets.API.Models;
using Tickets.API.Services.Interfaces;
using Tickets.Domain.Entities;
using Tickets.Domain.Enums;
using Tickets.Domain.Interfaces;
using Tickets.Infrastructure.MessageBroker.Interfaces;

namespace Tickets.API.Tests.Controllers
{
    public class PaymentsControllerTests
    {
        private readonly Mock<IOfferRepository> _offerRepoMock = new();
        private readonly Mock<IValidatorService> _validatorMock = new();
        private readonly Mock<IUnitOfWork> _unitOfWork = new();
        private readonly Mock<IMessagePublisher> _messagePublisher = new();

        private PaymentsController CreateController() =>
            new PaymentsController(
                _offerRepoMock.Object,
                _validatorMock.Object,
                _unitOfWork.Object,
                _messagePublisher.Object);

        [Fact]
        public async Task GetPaymentStatusAsync_ValidInput_ReturnsOfferStatus()
        {
            // Arrange
            var paymentId = Guid.NewGuid();
            var input = new PaymentInput { PaymentId = paymentId };
            var offer = new Offer(paymentId, Guid.NewGuid(), DateTime.UtcNow);
            offer.BookSeats();

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _offerRepoMock.Setup(r => r.GetAsync(paymentId)).ReturnsAsync(offer);

            var controller = CreateController();

            // Act
            var result = await controller.GetPaymentStatusAsync(input);

            // Assert
            Assert.Equal(OfferStatus.Sent, result);
            _validatorMock.Verify(v => v.ValidateAsync(input), Times.Once);
            _offerRepoMock.Verify(r => r.GetAsync(paymentId), Times.Once);
        }

        [Fact]
        public async Task CompletePaymentAsync_ValidInput_UpdatesAndReturnsStatus()
        {
            // Arrange
            var paymentId = Guid.NewGuid();
            var input = new PaymentInput { PaymentId = paymentId };
            var offer = new Offer(paymentId, Guid.NewGuid(), DateTime.UtcNow);
            offer.BookSeats();

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _offerRepoMock.Setup(r => r.GetAsync(paymentId)).ReturnsAsync(offer);
            _offerRepoMock.Setup(r => r.UpdateAsync(It.IsAny<Offer>()))
                .ReturnsAsync((Offer o) => o);

            var controller = CreateController();

            // Act
            var result = await controller.CompletePaymentAsync(input);

            // Assert
            Assert.Equal(OfferStatus.Paid, result);
            _validatorMock.Verify(v => v.ValidateAsync(input), Times.Once);
            _offerRepoMock.Verify(r => r.GetAsync(paymentId), Times.Once);
            _offerRepoMock.Verify(r => r.UpdateAsync(offer), Times.Once);
        }

        [Fact]
        public async Task FailPaymentAsync_ValidInput_UpdatesAndReturnsStatus()
        {
            // Arrange
            var paymentId = Guid.NewGuid();
            var input = new PaymentInput { PaymentId = paymentId };
            var offer = new Offer(paymentId, Guid.NewGuid(), DateTime.UtcNow);
            offer.BookSeats();

            _validatorMock.Setup(v => v.ValidateAsync(input)).Returns(Task.CompletedTask);
            _offerRepoMock.Setup(r => r.GetAsync(paymentId)).ReturnsAsync(offer);
            _offerRepoMock.Setup(r => r.UpdateAsync(It.IsAny<Offer>()))
                .ReturnsAsync((Offer o) => o);

            var controller = CreateController();

            // Act
            var result = await controller.FailPaymentAsync(input);

            // Assert
            Assert.Equal(OfferStatus.Failed, result);
            _validatorMock.Verify(v => v.ValidateAsync(input), Times.Once);
            _offerRepoMock.Verify(r => r.GetAsync(paymentId), Times.Once);
            _offerRepoMock.Verify(r => r.UpdateAsync(offer), Times.Once);
        }
    }
}
