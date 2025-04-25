using Microsoft.AspNetCore.Mvc;
using Tickets.Domain.Common;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        private readonly ISectionRepository _sectionRepoisotory;

        public EventsController(
            IEventRepository eventRepository,
            ISectionRepository sectionRepository)
        {
            _eventRepository = eventRepository ??
                throw new ArgumentNullException(nameof(eventRepository));

            _sectionRepoisotory = sectionRepository ??
                throw new ArgumentNullException(nameof(sectionRepository));
        }

        [HttpGet]
        public async Task<Paged<Event>> GetEventsAsync(
            int? pageIndex = null,
            int? pageSize = null)
        {
            return await _eventRepository.GetAsync(pageIndex ?? 1, pageSize ?? 1);
        }

        [HttpGet("{eventId}/sections/{sectionId}/seats")]
        public async Task<Paged<Seat>> GetSeatsInSectionsAsync(
            Guid eventId,
            Guid sectionId,
            int? pageIndex = null,
            int? pageSize = null)
        {
            return await _sectionRepoisotory.GetSeatsAsync(sectionId, pageIndex ?? 1, pageSize ?? 1);
        }
    }
}
