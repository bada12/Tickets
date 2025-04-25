using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tickets.DataAccess.Extensions;
using Tickets.Domain.Common;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.DataAccess.Repositories
{
    internal class EventRepository : IEventRepository
    {
        private readonly TicketsDbContext _dbContext;

        public EventRepository(
            TicketsDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Event> CreateAsync(Event @event)
        {
            EntityEntry<Event> createdEvent = await _dbContext.Events.AddAsync(@event);
            await _dbContext.SaveChangesAsync();

            return createdEvent.Entity;
        }

        public async Task DeleteAsync(Guid eventId)
        {
            await _dbContext.Events.Where(e => e.Id == eventId).ExecuteDeleteAsync();
        }

        public async Task DeleteAsync(Event @event)
        {
            _dbContext.Events.Remove(@event);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Paged<Event>> GetAsync(int pageIndex, int pageSize)
        {
            Paged<Event> events = await _dbContext.Events
                .AsNoTracking()
                .OrderByDescending(e => e.StartTime)
                .GetPaginatedDataAsync(pageIndex, pageSize);
            return events;
        }

        public async Task<Event> GetByIdAsync(Guid eventId)
        {
            Event @event = await _dbContext.Events.GetFirstOrThrowExceptionAsync(e => e.Id == eventId);
            return @event;
        }

        public async Task<Event> UpdateAsync(Event @event)
        {
            EntityEntry<Event> updatedEvent = _dbContext.Events.Update(@event);
            await _dbContext.SaveChangesAsync();

            return updatedEvent.Entity;
        }
    }
}
