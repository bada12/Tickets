using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tickets.Domain.Common;
using Tickets.Domain.Exceptions;

namespace Tickets.DataAccess.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<Paged<TEntity>> GetPaginatedDataAsync<TEntity>(
            this IQueryable<TEntity> query,
            int pageIndex,
            int pageSize)
            where TEntity : class
        {
            int totalCount = await query.CountAsync();
            IEnumerable<TEntity> entities = await query.Skip((pageIndex - 1) * pageSize).ToListAsync();
            Paged<TEntity> paged = Paged<TEntity>.Create(
                pageIndex,
                pageSize,
                totalCount,
                entities);

            return paged;
        }

        public static async Task<TEntity> GetFirstOrThrowExceptionAsync<TEntity>(
            this IQueryable<TEntity> query,
            Expression<Func<TEntity, bool>> expression,
            string errorMessage = "Object has not been found!")
            where TEntity : class
        {
            TEntity entity = await query.FirstOrDefaultAsync(expression) ??
                throw new ObjectNotFoundException(errorMessage);

            return entity;
        }
    }
}
