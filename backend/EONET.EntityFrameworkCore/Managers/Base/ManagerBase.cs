using EONET.Application.Services.Dto;
using EONET.EntityFrameworkCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EONET.Managers.Base
{
    public abstract class ManagerBase<TEntity, TPrimaryKey> : IManagerBase<TEntity, TPrimaryKey>
        where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        protected readonly EONETDbContext context;

        public ManagerBase(EONETDbContext context)
        {
            this.context = context;
            DbSet = context.Set<TEntity>();
        }

        public abstract Task<TEntity> GetEntityByIdAsync(TPrimaryKey id);
        protected async Task<TEntity> GetEntityByIdAsync(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (includeProperties != null)
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty.Trim());

            return await query.Where(predicate).FirstAsync();
        }

        //Must be implemented
        public abstract Task<Application.Services.Dto.PagedResult<TEntity>> GetAllAsync(PagedRequest input);
        protected async Task<Application.Services.Dto.PagedResult<TEntity>> GetAllAsync(PagedRequest input, string orderByDefault)
        {
            Application.Services.Dto.PagedResult<TEntity> result = new Application.Services.Dto.PagedResult<TEntity>();

            IQueryable<TEntity> data;
            string completeFilters = string.Empty;
            string completeOrderBy = string.Empty;

            /** Where **/
            if (!string.IsNullOrWhiteSpace(input.userFilters))
                completeFilters = input.userFilters.Trim();

            if (!string.IsNullOrWhiteSpace(completeFilters))
                data = DbSet.Where(completeFilters);
            else
                data = DbSet;

            /** Refresh data counter **/
            result.rowCount = await data.CountAsync();

            /** Order By **/
            if (!string.IsNullOrWhiteSpace(orderByDefault) && !string.IsNullOrWhiteSpace(input.orderBy))
                completeOrderBy = string.Concat(input.orderBy, ", ", orderByDefault);
            else if (!string.IsNullOrWhiteSpace(input.orderBy))
                completeOrderBy = input.orderBy;
            else if (!string.IsNullOrWhiteSpace(orderByDefault))
                completeOrderBy = orderByDefault;

            if (!string.IsNullOrWhiteSpace(completeOrderBy))
                data = data.OrderBy(completeOrderBy);

            /** Jump to the right page **/
            if (input.currentPage > 0 && input.pageSize > 0)
                data = data.Skip(input.currentPage * input.pageSize);
            if (input.pageSize > 0)
                data = data.Take(input.pageSize);

            result.queryable = data;
            return result;
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
