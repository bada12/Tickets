using Microsoft.AspNetCore.Mvc;
using Tickets.API.Models;
using Tickets.API.Services.Interfaces;
using Tickets.Domain.Entities;
using Tickets.Domain.Enums;
using Tickets.Domain.Interfaces;

namespace Tickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IValidatorService _validatorService;

        public PaymentsController(
            IOfferRepository offerRepository,
            IValidatorService validatorService)
        {
            _offerRepository = offerRepository ??
                throw new ArgumentNullException(nameof(offerRepository));

            _validatorService = validatorService ??
                throw new ArgumentNullException(nameof(validatorService));
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

            Offer offer = await _offerRepository.GetAsync(input.PaymentId);

            offer.CompletePayment();

            offer = await _offerRepository.UpdateAsync(offer);

            return offer.Status;
        }

        [HttpPost("{paymentId}/fail")]
        public async Task<OfferStatus> FailPaymentAsync(PaymentInput input)
        {
            await _validatorService.ValidateAsync(input);

            Offer offer = await _offerRepository.GetAsync(input.PaymentId);

            offer.FailPayment();

            offer = await _offerRepository.UpdateAsync(offer);

            return offer.Status;
        }
    }
}
