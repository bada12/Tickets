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
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISectionRepository _sectionRepoisotory;
        private readonly IValidatorService _validatorService;
        private readonly ICacheService _cacheService;

        public EventsController(
            IEventRepository eventRepository,
            ISectionRepository sectionRepository,
            IValidatorService validatorService,
            ICacheService cacheService)
        {
            _eventRepository = eventRepository ??
                throw new ArgumentNullException(nameof(eventRepository));

            _sectionRepoisotory = sectionRepository ??
                throw new ArgumentNullException(nameof(sectionRepository));

            _validatorService = validatorService ??
                throw new ArgumentNullException(nameof(validatorService));

            _cacheService = cacheService ??
                throw new ArgumentNullException(nameof(cacheService));
        }

        [HttpGet]
        public async Task<Paged<Event>> GetEventsAsync(
            PaginationInput input)
        {
            await _validatorService.ValidateAsync(input);

            Paged<Event> events = await _eventRepository.GetAsync(input.PageIndex, input.PageSize);

            _cacheService.SetList(events.Entities);

            return events;
        }

        [HttpGet("{eventId}/sections/{sectionId}/seats")]
        public async Task<Paged<Seat>> GetSeatsInSectionsAsync(
            GetSeatsInSectionsInput input)
        {
            await _validatorService.ValidateAsync(input);

            Paged<Seat> seats = await _sectionRepoisotory.GetSeatsAsync(
                input.SectionId,
                input.Pagination.PageIndex,
                input.Pagination.PageSize);

            _cacheService.SetList(seats.Entities);

            return seats;
        }
    }
}
