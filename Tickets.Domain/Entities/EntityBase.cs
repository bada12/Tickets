namespace Tickets.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
