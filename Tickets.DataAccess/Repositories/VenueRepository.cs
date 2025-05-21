using Microsoft.EntityFrameworkCore;
using Tickets.DataAccess.Extensions;
using Tickets.Domain.Common;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.DataAccess.Repositories
{
    internal class VenueRepository : IVenueRepository
    {
        private readonly TicketsDbContext _dbContext;

        public VenueRepository(TicketsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Paged<Venue>> GetAsync(int? pageIndex, int? pageSize)
        {
            Paged<Venue> venues = await _dbContext.Venues
                .AsNoTracking()
                .OrderBy(v => v.Address)
                .GetPaginatedDataAsync(pageIndex, pageSize);
            return venues;
        }
    }
}
