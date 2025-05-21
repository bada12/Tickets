using Microsoft.AspNetCore.Mvc;

namespace Tickets.API.Models
{
    public record GetCartInput
    {
        [FromRoute]
        public Guid CartId { get; init; }
    }
}
