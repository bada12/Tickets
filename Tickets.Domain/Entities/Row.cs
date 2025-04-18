namespace Tickets.Domain.Entities
{
    public class Row
    {
        public Guid Id { get; set; }

        public int? Number { get; set; }

        public Guid SectionId { get; set; }

        public ICollection<Seat> Seats { get; set; }
    }
}
