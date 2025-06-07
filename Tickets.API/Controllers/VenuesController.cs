using Microsoft.AspNetCore.Mvc;
using Tickets.API.Models;
using Tickets.API.Services.Interfaces;
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
        private readonly IValidatorService _validatorService;

        public VenuesController(
            IVenueRepository venueRepository,
            ISectionRepository sectionRepository,
            IValidatorService validatoService)
        {
            _venueRepository = venueRepository ??
                throw new ArgumentNullException(nameof(venueRepository));

            _sectionRepository = sectionRepository ??
                throw new ArgumentNullException(nameof(sectionRepository));

            _validatorService = validatoService ??
                throw new ArgumentNullException(nameof(validatoService));
        }

        [HttpGet]
        public async Task<Paged<Venue>> GetVenuesAsync(PaginationInput input)
        {
            await _validatorService.ValidateAsync(input);

            return await _venueRepository.GetAsync(input.PageIndex, input.PageSize);
        }

        [HttpGet("{venueid}/sections")]
        public async Task<Paged<Section>> GetSectionsByVenueIdAsync(GetSectionsByVenueInput input)
        {
            await _validatorService.ValidateAsync(input);

            return await _sectionRepository.GetAsync(input.VenueId, input.Pagination.PageIndex, input.Pagination.PageSize);
        }
    }
}
