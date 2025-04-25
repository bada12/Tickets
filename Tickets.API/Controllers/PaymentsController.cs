using Microsoft.AspNetCore.Mvc;
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

        public PaymentsController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository ??
                throw new ArgumentNullException(nameof(offerRepository));
        }

        [HttpGet("{paymentId}")]
        public async Task<OfferStatusEnum> GetPaymentStatusAsync(Guid paymentId)
        {
            Offer offer = await _offerRepository.GetAsync(paymentId);

            return offer.Status;
        }

        [HttpPost("{paymentId}/complete")]
        public async Task<OfferStatusEnum> CompletePaymentAsync(Guid paymentId)
        {
            Offer offer = await _offerRepository.GetAsync(paymentId);

            offer.CompletePayment();

            offer = await _offerRepository.UpdateAsync(offer);

            return offer.Status;
        }

        [HttpPost("{paymentId}/fail")]
        public async Task<OfferStatusEnum> FailPaymentAsync(Guid paymentId)
        {
            Offer offer = await _offerRepository.GetAsync(paymentId);

            offer.FailPayment();

            offer = await _offerRepository.UpdateAsync(offer);

            return offer.Status;
        }
    }
}
