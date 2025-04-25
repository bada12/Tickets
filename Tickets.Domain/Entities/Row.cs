namespace Tickets.Domain.Entities
{
    public class Row
    {
        public Row(
            Guid id,
            int? number,
            Guid sectionId)
        {
            Id = id;
            Number = number;
            SectionId = sectionId;
        }

        public Guid Id { get; private set; }

        public int? Number { get; private set; }

        public Guid SectionId { get; private set; }

        public Section Section { get; private set; }

        public ICollection<Seat> Seats { get; private set; }
    }
}
