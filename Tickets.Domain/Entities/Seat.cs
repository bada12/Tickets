using Tickets.Domain.Enums;

namespace Tickets.Domain.Entities
{
    public class Seat
    {
        public Guid Id { get; set; }

        public int? Number { get; set; }

        public Guid? RowId { get; set; }

        public decimal Price { get; set; }

        public PriceLevelEnum PriceLevel { get; set; }

        public SeatStatusEnum Status { get; set; }

        public Guid? OfferId { get; set; }

        public Offer Offer { get; set; }

        public PriceLevel LevelPrice { get; set; }
    }
}
