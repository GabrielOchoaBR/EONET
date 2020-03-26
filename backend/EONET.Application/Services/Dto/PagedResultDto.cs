using System.Collections.Generic;

namespace EONET.Application.Services.Dto
{
    public class PagedResultDto<TEntity>
    {
        public PagedResultDto() { }

        public PagedResultDto(int rowCount, ICollection<TEntity> queryable)
        {
            this.queryable = queryable;
            this.rowCount = rowCount;
        }

        public ICollection<TEntity> queryable { get; set; }

        public int rowCount { get; set; }
    }
}
