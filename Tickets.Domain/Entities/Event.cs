namespace Tickets.Domain.Entities
{
    public class Event : EntityBase
    {
        public Event(
            Guid id,
            string name,
            Guid createdBy,
            DateTime startTime)
            : base(id)
        {
            Name = name;
            CreatedBy = createdBy;
            StartTime = startTime;
        }

        public string Name { get; private set; }

        public Guid CreatedBy { get; private set; }

        public DateTime StartTime { get; private set; }

        public Venue Venue { get; private set; }

        public Manager Manager { get; private set; }
    }
}
