using Tickets.Domain.Enums;

namespace Tickets.Domain.Entities
{
    public class PriceLevel
    {
        public PriceLevelEnum Level { get; set; }

        public double PriceMultiplier { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}
