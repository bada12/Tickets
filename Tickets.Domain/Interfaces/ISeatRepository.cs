using Tickets.Domain.Entities;
using Tickets.Domain.Enums;

namespace Tickets.Domain.Interfaces
{
    public interface ISeatRepository
    {
        Task<Seat> GetAsync(Guid seatId);
        Task<Entities.PriceLevel> GetPriceLevelAsync(Enums.PriceLevel priceLevel);
    }
}
