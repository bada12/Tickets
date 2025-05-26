using Microsoft.EntityFrameworkCore;
using Tickets.DataAccess.Repositories;
using Tickets.Tests.Common;

namespace Tickets.DataAccess.Tests.Repositories
{
    public class EventRepositoryTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddEvent()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(CreateAsync_ShouldAddEvent));
            var repository = new EventRepository(dbContext);

            var evt = ModelCreationHelper.CreateEvent();

            var created = await repository.CreateAsync(evt);

            Assert.Equal(evt.Id, created.Id);
            Assert.Equal(evt.Name, created.Name);
        }

        [Fact]
        public async Task DeleteAsync_ByEntity_ShouldDeleteEvent()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(DeleteAsync_ByEntity_ShouldDeleteEvent));
            var evt = ModelCreationHelper.CreateEvent();
            dbContext.Events.Add(evt);
            await dbContext.SaveChangesAsync();

            var repository = new EventRepository(dbContext);
            await repository.DeleteAsync(evt);

            var exists = await dbContext.Events.AnyAsync(e => e.Id == evt.Id);
            Assert.False(exists);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectEvent()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetByIdAsync_ShouldReturnCorrectEvent));
            var evt = ModelCreationHelper.CreateEvent();
            dbContext.Events.Add(evt);
            await dbContext.SaveChangesAsync();

            var repository = new EventRepository(dbContext);
            var result = await repository.GetByIdAsync(evt.Id);

            Assert.Equal(evt.Name, result.Name);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnPagedEvents()
        {
            var dbContext = DbContextCreationHelper.CreateInMemoryDbContext(nameof(GetAsync_ShouldReturnPagedEvents));
            dbContext.Events.AddRange(Enumerable.Range(1, 10).Select(i => ModelCreationHelper.CreateEvent()));
            await dbContext.SaveChangesAsync();

            var repository = new EventRepository(dbContext);
            var result = await repository.GetAsync(1, 5);

            Assert.NotNull(result);
            Assert.Equal(5, result.Entities.Count());
        }
    }
}
