using Tickets.Domain.Enums;

namespace Tickets.Domain.Exceptions
{
    [Serializable]
    public class SeatIsNotAvailableException : Exception
    {
        public SeatIsNotAvailableException()
            : base($"The seat is not available due to its status - {SeatStatus.Booked} or {SeatStatus.Purchased}")
        {
        }
    }
}
