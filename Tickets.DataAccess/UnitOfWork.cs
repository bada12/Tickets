using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using Tickets.Domain.Interfaces;

namespace Tickets.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TicketsDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(TicketsDbContext dbContext)
        {
            _dbContext = dbContext ??
                throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task BeginTransactionAsync()
        {
            if (_transaction is not null)
            {
                return;
            }

            _transaction = await _dbContext.Database.BeginTransactionAsync(IsolationLevel.Serializable);
        }

        public async Task CommitAsync()
        {
            if (_transaction is null)
            {
                throw new InvalidOperationException("A transaction has not been started.");
            }

            await _transaction.CommitAsync();

            _transaction.Dispose();
            _transaction = null;
        }
    }
}
