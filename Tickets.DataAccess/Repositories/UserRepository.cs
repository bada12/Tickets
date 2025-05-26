using Microsoft.EntityFrameworkCore.ChangeTracking;
using Tickets.DataAccess.Extensions;
using Tickets.Domain.Entities;
using Tickets.Domain.Interfaces;

namespace Tickets.DataAccess.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly TicketsDbContext _dbContext;

        public UserRepository(TicketsDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<User> CreateAsync(User user)
        {
            EntityEntry<User> createdUser = await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return createdUser.Entity;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            User user = await _dbContext.Users.GetFirstOrThrowExceptionAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            User user = await _dbContext.Users.GetFirstOrThrowExceptionAsync(u => u.Username == username);
            return user;
        }
    }
}
