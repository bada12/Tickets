using Tickets.Domain.Common;
using Tickets.Domain.Entities;

namespace Tickets.Domain.Interfaces
{
    public interface IVenueRepository
    {
        Task<Paged<Venue>> GetAsync(int pageIndex, int pageSize);
    }
}
