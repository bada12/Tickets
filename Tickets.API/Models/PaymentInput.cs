using Microsoft.AspNetCore.Mvc;

namespace Tickets.API.Models
{
    public record PaymentInput
    {
        [FromRoute]
        public Guid PaymentId { get; init; }
    }
}
