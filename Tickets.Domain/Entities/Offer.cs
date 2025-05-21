using Tickets.Domain.Enums;

namespace Tickets.Domain.Entities
{
    public class Offer
    {
        public Offer(
            Guid id,
            Guid userId,
            DateTime timestamp)
        {
            Id = id;
            UserId = userId;
            Timestamp = timestamp;
        }

        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }

        public DateTime Timestamp { get; private set; }

        public decimal TotalAmount { get; private set; }

        public OfferStatus Status { get; private set; }

        public double? Discount { get; private set; }

        public User User { get; private set; }

        public ICollection<Seat> Seats { get; private set; } = new List<Seat>();

        public void TryToDeleteSeat(Guid seatId)
        {
            Seat seat = Seats?.SingleOrDefault(s => s.Id == seatId);
            if (seat is null)
            {
                return;
            }

            seat.SetOfferId(null);
            Seats.Remove(seat);

            RecalculateTotalAmount();
        }

        public void BookSeats()
        {
            foreach (Seat seat in Seats)
            {
                seat.Book();
            }
        }

        public void AddSeat(
            Seat seat,
            PriceLevel priceLevel)
        {
            seat.SetOfferId(Id);
            seat.SetPriceLevel(priceLevel);

            Seats.Add(seat);

            RecalculateTotalAmount();
        }

        public void CompletePayment()
        {
            foreach (Seat seat in Seats)
            {
                seat.SetPurchasedStatus();
            }

            Status = OfferStatus.Paid;
        }

        public void FailPayment()
        {
            foreach (Seat seat in Seats)
            {
                seat.SetAvailableStatus();
            }

            Status = OfferStatus.Failed;
        }

        private void RecalculateTotalAmount()
        {
            TotalAmount = Seats.Sum(s => s.Price * (decimal)s.LevelPrice.PriceMultiplier);
        }
    }
}
