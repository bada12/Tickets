using System.ComponentModel.DataAnnotations;
using Tickets.Domain.Enums;
using Tickets.Domain.Exceptions;

namespace Tickets.Domain.Entities
{
    public class Offer : EntityBase
    {
        public Offer(
            Guid id,
            Guid userId,
            DateTime timestamp)
            : base(id)
        {
            UserId = userId;
            Timestamp = timestamp;
        }

        public Guid UserId { get; private set; }

        public DateTime Timestamp { get; private set; }

        public decimal TotalAmount { get; private set; }

        public OfferStatus Status { get; private set; }

        public double? Discount { get; private set; }

        public User User { get; private set; }

        public ICollection<Seat> Seats { get; private set; } = new List<Seat>();

        [Timestamp]
        public byte[] Version { get; set; }

        public decimal CalculatePrice()
        {
            decimal price = TotalAmount - (decimal)Discount.GetValueOrDefault();
            return price;
        }

        public void TryToDeleteSeat(Guid seatId)
        {
            Seat seat = Seats?.SingleOrDefault(s => s.Id == seatId);
            if (seat is null)
            {
                return;
            }

            seat.SetOfferId(null);
            seat.SetAvailableStatus();
            Seats.Remove(seat);

            RecalculateTotalAmount();
        }

        public void BookSeats()
        {
            foreach (Seat seat in Seats)
            {
                seat.Book();
            }

            Status = OfferStatus.Sent;
        }

        public void AddSeat(
            Seat seat,
            PriceLevel priceLevel)
        {
            if (seat.Status is SeatStatus.Booked
                            or SeatStatus.Purchased)
            {
                throw new SeatIsNotAvailableException();
            }

            seat.SetOfferId(Id);
            seat.SetPriceLevel(priceLevel);
            seat.Book(); // for testing purposes

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
