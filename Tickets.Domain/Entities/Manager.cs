namespace Tickets.Domain.Entities
{
    public class Manager : User
    {
        public ICollection<Event> Events { get; set; }
    }
}
