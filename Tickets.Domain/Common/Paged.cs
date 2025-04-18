namespace Tickets.Domain.Common
{
    public class Paged<TEntity>
        where TEntity : class
    {
        private Paged(
            int currentPage,
            int pageSize,
            int pageCount,
            IEnumerable<TEntity> entities)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            PageCount = pageCount;
            Entities = entities;
        }

        public int CurrentPage { get; private init; }

        public int PageSize { get; private init; }

        public int PageCount { get; private init; }

        public IEnumerable<TEntity> Entities { get; private init; }

        public static Paged<TEntity> Create(
            int pageIndex,
            int pageSize,
            int totalCount,
            IEnumerable<TEntity> entities)
        {
            int pageCount = (int)Math.Ceiling((double)totalCount / pageSize);

            return new Paged<TEntity>(
                currentPage: pageIndex,
                pageSize: pageSize,
                pageCount: pageCount,
                entities: entities);
        }
    }
}
