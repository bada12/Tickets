namespace Tickets.Domain.Entities
{
    public class Venue
    {
        public Guid Id { get; set; }

        public Guid EventId { get; set; }

        public string SpotName { get; set; }

        public string Address { get; set; }

        public Event Event { get; set; }

        public ICollection<Section> Sections { get; set; }
    }
}
