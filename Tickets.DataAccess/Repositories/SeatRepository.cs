using Tickets.DataAccess.Extensions;
using Tickets.Domain.Entities;
using Tickets.Domain.Enums;
using Tickets.Domain.Interfaces;

namespace Tickets.DataAccess.Repositories
{
    public class SeatRepository : ISeatRepository
    {
        private readonly TicketsDbContext _dbContext;

        public SeatRepository(TicketsDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Seat> GetAsync(Guid seatId)
        {
            Seat seat = await _dbContext.Seats.GetFirstOrThrowExceptionAsync(s => s.Id == seatId);
            return seat;
        }

        public async Task<Domain.Entities.PriceLevel> GetPriceLevelAsync(Domain.Enums.PriceLevel priceLevel)
        {
            Domain.Entities.PriceLevel priceLevelEntity = await _dbContext.PriceLevels.GetFirstOrThrowExceptionAsync(pl => pl.Level == priceLevel);
            return priceLevelEntity;
        }
    }
}
