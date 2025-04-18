using Tickets.Domain.Enums;

namespace Tickets.Domain.Entities
{
    public class Offer
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime Timestamp { get; set; }

        public decimal TotalAmount { get; set; }

        public OfferStatusEnum Status { get; set; }

        public double? Discount { get; set; }

        public User User { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}
