using AutoMapper;
using EONET.Application.Events.Dto;
using EONET.Application.Services;
using EONET.Application.Services.Dto;
using EONET.Domain.Entities;
using EONET.Managers.Events;
using System.Threading.Tasks;

namespace EONET.Application.Events
{
    public class EventAppService : AsyncCrudAppService<Event, EventResultCompletedDto, EventResultListDto, string>, IEventAppService
    {
        public EventAppService(IEventManager eventManager, IMapper mapper) : base(eventManager, mapper) { }
    }
}
