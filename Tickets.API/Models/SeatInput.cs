using Tickets.Domain.Enums;

namespace Tickets.API.Models
{
    public record SeatInput(
        Guid EventId,
        Guid SeatId,
        PriceLevel PriceLevel,
        Guid UserId);
}
