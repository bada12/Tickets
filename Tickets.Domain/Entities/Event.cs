namespace Tickets.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime StartTime { get; set; }

        public Venue Venue { get; set; }

        public Manager Manager { get; set; }
    }
}
