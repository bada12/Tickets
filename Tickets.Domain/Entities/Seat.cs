using Tickets.Domain.Enums;

namespace Tickets.Domain.Entities
{
    public class Seat : EntityBase
    {
        public Seat(
            Guid id,
            int? number,
            Guid? rowId,
            decimal price)
            : base(id)
        {
            Number = number;
            RowId = rowId;
            Price = price;
            PriceLevel = Enums.PriceLevel.Adult;
            Status = SeatStatus.Available;
        }

        public int? Number { get; private set; }

        public Guid? RowId { get; private set; }

        public decimal Price { get; private set; }

        public Enums.PriceLevel PriceLevel { get; private set; }

        public SeatStatus Status { get; private set; }

        public Guid? OfferId { get; private set; }

        public Row Row { get; private set; }

        public Offer Offer { get; private set; }

        public PriceLevel LevelPrice { get; private set; }

        internal void Book()
        {
            Status = SeatStatus.Booked;
        }

        internal void SetOfferId(Guid? id)
        {
            OfferId = id;
        }

        internal void SetPriceLevel(PriceLevel priceLevel)
        {
            PriceLevel = priceLevel.Level;
            LevelPrice = priceLevel;
        }

        internal void SetPurchasedStatus()
        {
            Status = SeatStatus.Purchased;
        }

        internal void SetAvailableStatus()
        {
            Status = SeatStatus.Available;
        }
    }
}
