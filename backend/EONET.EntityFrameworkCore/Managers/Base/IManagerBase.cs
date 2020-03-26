using EONET.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EONET.Managers.Base
{
    public interface IManagerBase<TEntity, TPrimaryKey> : IDisposable
        where TEntity : class
    {
        Task<TEntity> GetEntityByIdAsync(TPrimaryKey id);
        Task<PagedResult<TEntity>> GetAllAsync(PagedRequest input);
    }
}
