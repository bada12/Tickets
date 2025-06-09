using Tickets.Domain.Enums;

namespace Tickets.Infrastructure.MessageBroker.Messages
{
    public record PaymentNotificationMessage : BaseMessage
    {
        public PaymentNotificationMessage(
            Guid offerId,
            Guid userId,
            string email,
            decimal price,
            OfferStatus status)
        {
            OfferId = offerId;
            UserId = userId;
            Email = email;
            Price = price;
            Status = status;
        }

        public Guid OfferId { get; init; }

        public Guid UserId { get; init; }

        public string Email { get; init; }

        public decimal Price { get; init; }

        public OfferStatus Status { get; init; }
    }
}
