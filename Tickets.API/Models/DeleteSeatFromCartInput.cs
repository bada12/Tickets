using Microsoft.AspNetCore.Mvc;

namespace Tickets.API.Models
{
    public record DeleteSeatFromCartInput
    {
        [FromRoute]
        public Guid CartId { get; init; }

        [FromRoute]
        public Guid EventId { get; init; }

        [FromRoute]
        public Guid SeatId { get; init; }
    }
}
