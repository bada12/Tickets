
namespace Tickets.Domain.Entities
{
    public class Manager : User
    {
        public Manager(
            Guid id,
            string firstName,
            string lastName,
            string email,
            string username,
            string password)
            : base(
                  id,
                  firstName,
                  lastName,
                  email,
                  username,
                  password)
        {
        }

        public ICollection<Event> Events { get; private set; }
    }
}
