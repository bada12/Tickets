using Tickets.Domain.Enums;

namespace Tickets.Domain.Entities
{
    public class Seat
    {
        public Seat(
            Guid id,
            int? number,
            Guid? rowId,
            decimal price)
        {
            Id = id;
            Number = number;
            RowId = rowId;
            Price = price;
            PriceLevel = PriceLevelEnum.Adult;
            Status = SeatStatusEnum.Available;
        }

        public Guid Id { get; private set; }

        public int? Number { get; private set; }

        public Guid? RowId { get; private set; }

        public decimal Price { get; private set; }

        public PriceLevelEnum PriceLevel { get; private set; }

        public SeatStatusEnum Status { get; private set; }

        public Guid? OfferId { get; private set; }

        public Row Row { get; private set; }

        public Offer Offer { get; private set; }

        public PriceLevel LevelPrice { get; private set; }

        internal void Book()
        {
            Status = SeatStatusEnum.Booked;
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
            Status = SeatStatusEnum.Purchased;
        }

        internal void SetAvailableStatus()
        {
            Status = SeatStatusEnum.Available;
        }
    }
}
