using Tickets.DataAccess.Repositories;
using Tickets.Tests.Common;

namespace Tickets.DataAccess.Tests.Repositories
{
    public class UserRepositoryTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddUser()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(CreateAsync_ShouldAddUser));
            var repository = new UserRepository(dbContext);

            var user = ModelCreationHelper.CreateUser();

            var createdUser = await repository.CreateAsync(user);

            Assert.Equal(user.Id, createdUser.Id);
            Assert.Equal(user.Email, createdUser.Email);
            Assert.Equal(user.Username, createdUser.Username);
        }

        [Fact]
        public async Task GetByEmailAsync_ShouldReturnUser()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetByEmailAsync_ShouldReturnUser));

            var user = ModelCreationHelper.CreateUser();
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            var repository = new UserRepository(dbContext);
            var result = await repository.GetByEmailAsync(user.Email);

            Assert.Equal(user.Id, result.Id);
        }

        [Fact]
        public async Task GetByUsernameAsync_ShouldReturnUser()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetByUsernameAsync_ShouldReturnUser));
            var user = ModelCreationHelper.CreateUser();
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            var repository = new UserRepository(dbContext);
            var result = await repository.GetByUsernameAsync(user.Username);

            Assert.Equal(user.Email, result.Email);
        }
    }
}
