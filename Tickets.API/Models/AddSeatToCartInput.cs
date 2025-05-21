using Microsoft.AspNetCore.Mvc;

namespace Tickets.API.Models
{
    public record AddSeatToCartInput
    {
        [FromRoute]
        public Guid CartId { get; init; }

        [FromBody]
        public SeatInput SeatInput { get; init; }
    }
}
