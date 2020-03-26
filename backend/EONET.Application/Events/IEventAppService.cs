using EONET.Application.Events.Dto;
using EONET.Application.Services;
using EONET.Application.Services.Dto;
using EONET.Domain.Entities;

namespace EONET.Application.Events
{
    public interface IEventAppService : IAsyncCrudAppService<Event, EventResultCompletedDto, EventResultListDto, string>
    { 
    
    }
}
