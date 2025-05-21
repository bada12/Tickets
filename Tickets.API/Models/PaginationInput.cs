using Microsoft.AspNetCore.Mvc;

namespace Tickets.API.Models
{
    public record PaginationInput
    {
        [FromQuery]
        public int? PageIndex { get; init; }

        [FromQuery]
        public int? PageSize { get; init; }
    }
}
