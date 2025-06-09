using Microsoft.AspNetCore.Mvc;
using Tickets.API.Models;
using Tickets.API.Services.Interfaces;
using Tickets.Domain.Entities;
using Tickets.Domain.Enums;
using Tickets.Domain.Interfaces;
using Tickets.Infrastructure.MessageBroker.Interfaces;
using Tickets.Infrastructure.MessageBroker.Messages;
using Tickets.Infrastructure.MessageBroker.RabbitMq;

namespace Tickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IValidatorService _validatorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessagePublisher _messagePublisher;

        public PaymentsController(
            IOfferRepository offerRepository,
            IValidatorService validatorService,
            IUnitOfWork unitOfWork,
            IMessagePublisher messagePublisher)
        {
            _offerRepository = offerRepository ??
                throw new ArgumentNullException(nameof(offerRepository));

            _validatorService = validatorService ??
                throw new ArgumentNullException(nameof(validatorService));

            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));

            _messagePublisher = messagePublisher ??
                throw new ArgumentNullException(nameof(messagePublisher));
        }

        [HttpGet("{paymentId}")]
        public async Task<OfferStatus> GetPaymentStatusAsync(PaymentInput input)
        {
            await _validatorService.ValidateAsync(input);

            Offer offer = await _offerRepository.GetAsync(input.PaymentId);

            return offer.Status;
        }

        [HttpPost("{paymentId}/complete")]
        public async Task<OfferStatus> CompletePaymentAsync(PaymentInput input)
        {
            await _validatorService.ValidateAsync(input);

            await _unitOfWork.BeginTransactionAsync();

            Offer offer = await _offerRepository.GetAsync(input.PaymentId);

            offer.CompletePayment();

            offer = await _offerRepository.UpdateAsync(offer);

            await SendPaymentNotificationMessageAsync(offer);

            await _unitOfWork.CommitAsync();

            return offer.Status;
        }

        [HttpPost("{paymentId}/fail")]
        public async Task<OfferStatus> FailPaymentAsync(PaymentInput input)
        {
            await _validatorService.ValidateAsync(input);

            await _unitOfWork.BeginTransactionAsync();

            Offer offer = await _offerRepository.GetAsync(input.PaymentId);

            offer.FailPayment();

            offer = await _offerRepository.UpdateAsync(offer);

            await SendPaymentNotificationMessageAsync(offer);

            await _unitOfWork.CommitAsync();

            return offer.Status;
        }

        private async Task SendPaymentNotificationMessageAsync(Offer offer)
        {
            PaymentNotificationMessage message = new(
                offerId: offer.Id,
                userId: offer.UserId,
                email: offer.User?.Email,
                price: offer.CalculatePrice(),
                status: offer.Status);

            await _messagePublisher.PublishMessageAsync(
                message,
                RabbitMQQueues.PaymentNotificationQueue);
        }
    }
}
