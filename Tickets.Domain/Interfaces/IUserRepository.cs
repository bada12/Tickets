using Tickets.Domain.Entities;

namespace Tickets.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetByUsernameAsync(string username);
    }
}
