using Microsoft.AspNetCore.Mvc;

namespace Tickets.API.Models
{
    public record BookSeatsInput
    {
        [FromRoute]
        public Guid CartId { get; init; }
    }
}
