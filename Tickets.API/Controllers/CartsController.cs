using Microsoft.AspNetCore.Mvc;
using Tickets.API.Models;
using Tickets.API.Services;
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
        private readonly IValidatorService _validatorService;

        public CartsController(
            IOfferRepository offerRepository,
            ISeatRepository seatRepository,
            IValidatorService validatorService)
        {
            _offerRepository = offerRepository ??
                throw new ArgumentNullException(nameof(offerRepository));

            _seatRepository = seatRepository ??
                throw new ArgumentNullException(nameof(seatRepository));

            _validatorService = validatorService ??
                throw new ArgumentNullException(nameof(validatorService));
        }

        [HttpGet("{cartId}")]
        public async Task<Offer> GetCartAsync(GetCartInput input)
        {
            await _validatorService.ValidateAsync(input);
            return await _offerRepository.GetAsync(input.CartId);
        }

        [HttpPost("{cartId}")]
        public async Task<Offer> AddSeatToCartAsync(AddSeatToCartInput input)
        {
            await _validatorService.ValidateAsync(input);

            Offer offer = await _offerRepository.GetAsync(input.CartId);
            Seat seat = await _seatRepository.GetAsync(input.SeatInput.SeatId);

            if (offer is null)
            {
                offer = new Offer(
                    input.CartId,
                    userId: input.SeatInput.UserId,
                    timestamp: DateTime.UtcNow);

                offer = await _offerRepository.CreateAsync(offer);
            }

            PriceLevel priceLevel = await _seatRepository.GetPriceLevelAsync(input.SeatInput.PriceLevel);

            offer.AddSeat(seat, priceLevel);

            offer = await _offerRepository.UpdateAsync(offer);
            return offer;
        }

        [HttpDelete("{cartId}/events/{eventId}/seats/{seatId}")]
        public async Task DeleteSeatFromCartAsync(
            DeleteSeatFromCartInput input)
        {
            await _validatorService.ValidateAsync(input);

            Offer offer = await _offerRepository.GetAsync(input.CartId);

            offer.TryToDeleteSeat(input.SeatId);

            await _offerRepository.UpdateAsync(offer);
        }

        [HttpPut("{cartId}/book")]
        public async Task<Guid> BookSeatsAsync(BookSeatsInput input)
        {
            await _validatorService.ValidateAsync(input);

            Offer offer = await _offerRepository.GetAsync(input.CartId);

            offer.BookSeats();

            offer = await _offerRepository.UpdateAsync(offer);

            return offer.Id;
        }
    }
}
