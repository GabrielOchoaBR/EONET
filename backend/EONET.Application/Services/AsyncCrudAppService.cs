using AutoMapper;
using EONET.Application.Services.Dto;
using EONET.Managers.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EONET.Application.Services
{
    public abstract class AsyncCrudAppService<TEntity, TEntityResultCompletedDto, TEntityResultListDto, TPrimaryKey> : IAsyncCrudAppService<TEntity, TEntityResultCompletedDto, TEntityResultListDto, TPrimaryKey>
        where TEntity : class
        where TEntityResultCompletedDto : class
        where TEntityResultListDto : class
    {
        private readonly IManagerBase<TEntity, TPrimaryKey> _ServiceBase;
        private readonly IMapper _mapper;

        public AsyncCrudAppService(IManagerBase<TEntity, TPrimaryKey> serviceBase, IMapper mapper)
        {
            _ServiceBase = serviceBase;
            _mapper = mapper;
        }

        public async Task<PagedResultDto<TEntityResultListDto>> GetAllAsync(PagedRequestDto input)
        {
            var pagedRequest = _mapper.Map<PagedRequest>(input);

            var pageResult = await _ServiceBase.GetAllAsync(pagedRequest);

            return _mapper.Map<PagedResultDto<TEntityResultListDto>>(pageResult);
        }

        public async Task<TEntityResultCompletedDto> GetEntityByIdAsync(TPrimaryKey id)
        {
            var entityResult = await _ServiceBase.GetEntityByIdAsync(id);
            
            return _mapper.Map<TEntityResultCompletedDto>(entityResult);
        }
    }
}
