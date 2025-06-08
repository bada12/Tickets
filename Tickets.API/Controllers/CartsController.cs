using Microsoft.AspNetCore.Mvc;
using Tickets.API.Models;
using Tickets.API.Services.Interfaces;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidatorService _validatorService;
        private readonly ICacheService _cacheService;

        public CartsController(
            IOfferRepository offerRepository,
            ISeatRepository seatRepository,
            IUnitOfWork unitOfWork,
            IValidatorService validatorService,
            ICacheService cacheService)
        {
            _offerRepository = offerRepository ??
                throw new ArgumentNullException(nameof(offerRepository));

            _seatRepository = seatRepository ??
                throw new ArgumentNullException(nameof(seatRepository));

            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));

            _validatorService = validatorService ??
                throw new ArgumentNullException(nameof(validatorService));

            _cacheService = cacheService ??
                throw new ArgumentNullException(nameof(cacheService));
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

            await _unitOfWork.BeginTransactionAsync();

            Offer offer = await _offerRepository.GetAsync(input.CartId);
            Seat seat = await _seatRepository.GetAsync(input.SeatInput.SeatId);
            PriceLevel priceLevel = await _seatRepository.GetPriceLevelAsync(input.SeatInput.PriceLevel);

            if (offer is null)
            {
                offer = new Offer(
                    input.CartId,
                    userId: input.SeatInput.UserId,
                    timestamp: DateTime.UtcNow);

                offer = await _offerRepository.CreateAsync(offer);
            }

            offer.AddSeat(seat, priceLevel);

            offer = await _offerRepository.UpdateAsync(offer);

            _cacheService.RemoveList<Event>();

            await _unitOfWork.CommitAsync();

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

            _cacheService.RemoveList<Event>();
        }

        [HttpPut("{cartId}/book")]
        public async Task<Guid> BookSeatsAsync(BookSeatsInput input)
        {
            await _validatorService.ValidateAsync(input);

            Offer offer = await _offerRepository.GetAsync(input.CartId);

            offer.BookSeats();

            offer = await _offerRepository.UpdateAsync(offer);

            _cacheService.RemoveList<Event>();

            return offer.Id;
        }
    }
}
