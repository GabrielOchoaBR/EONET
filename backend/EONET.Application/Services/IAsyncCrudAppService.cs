using EONET.Application.Events.Dto;
using EONET.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EONET.Application.Services
{
    public interface IAsyncCrudAppService<TEntity, TEntityResultCompletedDto, TEntityResultListDto, TPrimaryKey>
        where TEntity : class
        where TEntityResultCompletedDto : class
        where TEntityResultListDto : class
    {
        public Task<TEntityResultCompletedDto> GetEntityByIdAsync(TPrimaryKey id);
        public Task<PagedResultDto<TEntityResultListDto>> GetAllAsync(PagedRequestDto pagedRequestDto);

        //Others methods to be implemented here, CreateAsync, UpdateAsync, DeleteAsync. 
    }
}
