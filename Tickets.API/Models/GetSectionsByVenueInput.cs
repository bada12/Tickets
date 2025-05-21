using Microsoft.AspNetCore.Mvc;

namespace Tickets.API.Models
{
    public record GetSectionsByVenueInput
    {
        [FromRoute]
        public Guid VenueId { get; init; }

        public PaginationInput Pagination { get; init; } = new();
    }
}
