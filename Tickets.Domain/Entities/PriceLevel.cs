using Tickets.Domain.Enums;

namespace Tickets.Domain.Entities
{
    public class PriceLevel
    {
        public PriceLevel()
        {
        }

        public PriceLevel(
            Enums.PriceLevel priceLevel,
            double priceMultiplier)
        {
            Level = priceLevel;
            PriceMultiplier = priceMultiplier;
        }

        public Enums.PriceLevel Level { get; private set; }

        public double PriceMultiplier { get; private set; }

        public ICollection<Seat> Seats { get; private set; }
    }
}
