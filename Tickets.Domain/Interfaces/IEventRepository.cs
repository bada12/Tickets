using Tickets.Domain.Common;
using Tickets.Domain.Entities;

namespace Tickets.Domain.Interfaces
{
    public interface IEventRepository
    {
        Task<Event> CreateAsync(Event @event);

        Task<Event> UpdateAsync(Event @event);

        Task DeleteAsync(Guid eventId);

        Task DeleteAsync(Event @event);

        Task<Event> GetByIdAsync(Guid eventId);

        Task<Paged<Event>> GetAsync(int? pageIndex, int? pageSize);
    }
}
