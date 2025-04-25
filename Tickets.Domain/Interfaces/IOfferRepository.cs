using Tickets.Domain.Common;
using Tickets.Domain.Entities;

namespace Tickets.Domain.Interfaces
{
    public interface IOfferRepository
    {
        Task<Offer> CreateAsync(Offer offer);

        Task<Offer> UpdateAsync(Offer offer);

        Task DeleteAsync(Guid offerId);

        Task<Offer> GetAsync(Guid offerId);

        Task<Paged<Offer>> GetByUserIdAsync(Guid customerId, int pageIndex, int pageSize);
    }
}
