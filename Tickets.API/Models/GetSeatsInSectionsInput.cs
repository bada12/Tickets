using Microsoft.AspNetCore.Mvc;

namespace Tickets.API.Models
{
    public record GetSeatsInSectionsInput
    {
        [FromRoute]
        public Guid EventId { get; init; }

        [FromRoute]
        public Guid SectionId { get; init; }

        public PaginationInput Pagination { get; init; } = new();
    }
}
