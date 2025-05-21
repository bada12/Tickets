using Microsoft.EntityFrameworkCore;
using Tickets.DataAccess.Extensions;
using Tickets.Domain.Common;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.DataAccess.Repositories
{
    public class SectionRepository : ISectionRepository
    {
        private readonly TicketsDbContext _dbContext;

        public SectionRepository(TicketsDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Paged<Section>> GetAsync(Guid venueId, int? pageIndex, int? pageSize)
        {
            Paged<Section> sections = await _dbContext.Sections
                .AsNoTracking()
                .OrderBy(s => s.Name)
                .Where(s => s.VenueId == venueId)
                .GetPaginatedDataAsync(pageIndex, pageSize);
            return sections;
        }

        public async Task<Paged<Seat>> GetSeatsAsync(Guid sectionId, int? pageIndex, int? pageSize)
        {
            Paged<Seat> seats = await _dbContext.Seats
                .AsNoTracking()
                .OrderBy(s => s.RowId)
                .ThenBy(s => s.Number)
                .Where(s => s.Row.SectionId == sectionId)
                .GetPaginatedDataAsync(pageIndex, pageSize);
            return seats;
        }
    }
}
