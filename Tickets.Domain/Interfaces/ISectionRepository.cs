using Tickets.Domain.Common;
using Tickets.Domain.Entities;

namespace Tickets.Domain.Interfaces
{
    public interface ISectionRepository
    {
        Task<Paged<Section>> GetAsync(Guid venueId, int pageIndex, int pageSize);

        Task<Paged<Seat>> GetSeatsAsync(Guid sectionId, int pageIndex, int pageSize);
    }
}
