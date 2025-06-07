namespace Tickets.Domain.Entities
{
    public class Row : EntityBase
    {
        public Row(
            Guid id,
            int? number,
            Guid sectionId)
            : base(id)
        {
            Number = number;
            SectionId = sectionId;
        }

        public int? Number { get; private set; }

        public Guid SectionId { get; private set; }

        public Section Section { get; private set; }

        public ICollection<Seat> Seats { get; private set; }
    }
}
