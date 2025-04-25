namespace Tickets.Domain.Entities
{
    public class User
    {
        public User(
            Guid id,
            string firstName,
            string lastName,
            string email,
            string username,
            string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
        }

        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public ICollection<Offer> Offers { get; private set; }
    }
}
