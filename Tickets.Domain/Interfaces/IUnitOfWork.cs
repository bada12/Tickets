namespace Tickets.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();

        Task CommitAsync();
    }
}
