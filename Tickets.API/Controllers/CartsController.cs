using Microsoft.AspNetCore.Mvc;
using Tickets.API.Models;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.API.Controllers
{
    [Route("orders/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly IOfferRepository _offerRepository;
        private readonly ISeatRepository _seatRepository;

        public CartsController(
            IOfferRepository offerRepository,
            ISeatRepository seatRepository)
        {
            _offerRepository = offerRepository ??
                throw new ArgumentNullException(nameof(offerRepository));

            _seatRepository = seatRepository ??
                throw new ArgumentNullException(nameof(seatRepository));
        }

        [HttpGet("{cartId}")]
        public async Task<Offer> GetCartAsync(Guid cartId)
        {
            return await _offerRepository.GetAsync(cartId);
        }

        [HttpPost("{cartId}")]
        public async Task<Offer> AddSeatToCartAsync(
            Guid cartId,
            [FromBody] SeatInput seatInput)
        {
            Offer offer = await _offerRepository.GetAsync(cartId);
            Seat seat = await _seatRepository.GetAsync(seatInput.SeatId);

            if (offer is null)
            {
                offer = new Offer(
                    cartId,
                    userId: seatInput.UserId,
                    timestamp: DateTime.UtcNow);

                offer = await _offerRepository.CreateAsync(offer);
            }

            PriceLevel priceLevel = await _seatRepository.GetPriceLevelAsync(seatInput.PriceLevel);

            offer.AddSeat(seat, priceLevel);

            offer = await _offerRepository.UpdateAsync(offer);
            return offer;
        }

        [HttpDelete("{cartId}/events/{eventId}/seats/{seatId}")]
        public async Task DeleteSeatFromCartAsync(
            Guid cartId,
            Guid eventId,
            Guid seatId)
        {
            Offer offer = await _offerRepository.GetAsync(cartId);

            offer.TryToDeleteSeat(seatId);

            await _offerRepository.UpdateAsync(offer);
        }

        [HttpPut("{cartId}/book")]
        public async Task<Guid> BookSeatsAsync(Guid cartId)
        {
            Offer offer = await _offerRepository.GetAsync(cartId);

            offer.BookSeats();

            offer = await _offerRepository.UpdateAsync(offer);

            return offer.Id;
        }
    }
}
