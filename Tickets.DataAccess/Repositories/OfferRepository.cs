using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tickets.DataAccess.Extensions;
using Tickets.Domain.Common;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.DataAccess.Repositories
{
    internal class OfferRepository : IOfferRepository
    {
        private readonly TicketsDbContext _dbContext;

        public OfferRepository(
            TicketsDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Offer> CreateAsync(Offer offer)
        {
            EntityEntry<Offer> createdOffer = await _dbContext.Offers.AddAsync(offer);
            await _dbContext.SaveChangesAsync();

            return createdOffer.Entity;
        }

        public async Task DeleteAsync(Guid offerId)
        {
            await _dbContext.Offers.Where(o => o.Id == offerId).ExecuteDeleteAsync();
        }

        public async Task<Paged<Offer>> GetByUserIdAsync(Guid userId, int pageIndex, int pageSize)
        {
            Paged<Offer> offers = await _dbContext.Offers
                .AsNoTracking()
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.Timestamp)
                .GetPaginatedDataAsync(pageIndex, pageSize);

            return offers;
        }

        public async Task<Offer> GetAsync(Guid offerId)
        {
            Offer offer = await _dbContext.Offers
                .Include(o => o.User)
                .Include(o => o.Seats)
                .FirstOrDefaultAsync(o => o.Id == offerId);
            return offer;
        }

        public async Task<Offer> UpdateAsync(Offer offer)
        {
            EntityEntry<Offer> updatedOffer = _dbContext.Offers.Update(offer);
            await _dbContext.SaveChangesAsync();

            return updatedOffer.Entity;
        }
    }
}
