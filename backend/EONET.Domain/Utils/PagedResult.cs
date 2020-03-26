using System.Linq;

namespace EONET.Application.Services.Dto
{
    public class PagedResult<TEntity>
    {
        public PagedResult() { }

        public PagedResult(int rowCount, IQueryable<TEntity> queryable)
        {
            this.queryable = queryable;
            this.rowCount = rowCount;
        }

        public IQueryable<TEntity> queryable { get; set; }

        public int rowCount { get; set; }
    }
}
