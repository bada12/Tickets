using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tickets.Domain.Common;
using Tickets.Domain.Exceptions;

namespace Tickets.DataAccess.Extensions
{
    public static class QueryableExtensions
    {
        private const int DefaultPageIndex = 1;
        private const int DefaultPageSize = 10;

        public static async Task<Paged<TEntity>> GetPaginatedDataAsync<TEntity>(
            this IQueryable<TEntity> query,
            int? pageIndex = null,
            int? pageSize = null)
            where TEntity : class
        {
            pageIndex ??= DefaultPageIndex;
            pageSize ??= DefaultPageSize;

            int totalCount = await query.CountAsync();
            IEnumerable<TEntity> entities = await query.Skip((pageIndex.Value - 1) * pageSize.Value).ToListAsync();

            Paged<TEntity> paged = Paged<TEntity>.Create(
                pageIndex.Value,
                pageSize.Value,
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
