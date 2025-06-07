namespace Tickets.Domain.Entities
{
    public class Section : EntityBase
    {
        public Section(
            Guid id,
            Guid venueId,
            string name)
            : base(id)
        {
            VenueId = venueId;
            Name = name;
        }

        public Guid VenueId { get; private set; }

        public string Name { get; private set; }

        public Venue Venue { get; private set; }

        public ICollection<Row> Rows { get; private set; }
    }
}
