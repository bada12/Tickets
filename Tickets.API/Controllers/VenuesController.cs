using Microsoft.AspNetCore.Mvc;
using Tickets.Domain.Common;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VenuesController : ControllerBase
    {
        private readonly IVenueRepository _venueRepository;
        private readonly ISectionRepository _sectionRepository;

        public VenuesController(
            IVenueRepository venueRepository,
            ISectionRepository sectionRepository)
        {
            _venueRepository = venueRepository ??
                throw new ArgumentNullException(nameof(venueRepository));

            _sectionRepository = sectionRepository ??
                throw new ArgumentNullException(nameof(sectionRepository));
        }

        [HttpGet]
        public async Task<Paged<Venue>> GetVenuesAsync(
            int? pageIndex = null,
            int? pageSize = null)
        {
            return await _venueRepository.GetAsync(pageIndex ?? 1, pageSize ?? 1);
        }

        [HttpGet("{venueid}/sections")]
        public async Task<Paged<Section>> GetSectionsByVenueIdAsync(
            Guid venueId,
            int? pageIndex = null,
            int? pageSize = null)
        {
            return await _sectionRepository.GetAsync(venueId, pageIndex ?? 1, pageSize ?? 1);
        }
    }
}
