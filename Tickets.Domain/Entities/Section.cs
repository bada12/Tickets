namespace Tickets.Domain.Entities
{
    public class Section
    {
        public Guid Id { get; set; }

        public Guid VenueId { get; set; }

        public string Name { get; set; }

        public Venue Venue { get; set; }

        public ICollection<Row> Rows { get; set; }
    }
}
