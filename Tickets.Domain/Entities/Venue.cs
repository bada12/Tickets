namespace Tickets.Domain.Entities
{
    public class Venue
    {
        public Venue(
            Guid id,
            Guid eventId,
            string spotName,
            string address)
        {
            Id = id;
            EventId = eventId;
            SpotName = spotName;
            Address = address;
        }

        public Guid Id { get; private set; }

        public Guid EventId { get; private set; }

        public string SpotName { get; private set; }

        public string Address { get; private set; }

        public Event Event { get; private set; }

        public ICollection<Section> Sections { get; private set; }
    }
}
