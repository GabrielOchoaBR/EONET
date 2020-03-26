using AutoMapper;
using EONET.Application.Events.Dto;
using EONET.Application.Services.Dto;
using EONET.Domain.Entities;

namespace EONET.Web.Core.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PagedRequestDto, PagedRequest>();

            CreateMap<Event, EventResultListDto>();
            CreateMap<PagedResult<Event>, PagedResultDto<EventResultListDto>>();

            CreateMap<Event, EventResultCompletedDto>();
            CreateMap<EventCategory, EventCategoryResultCompletedDto>();
            CreateMap<Category, CategoryResultCompletedDto>();
            CreateMap<EventSource, EventSourceResultCompletedDto>();
            CreateMap<Source, SourceResultCompletedDto>();
            CreateMap<Geometry, GeometryResultCompletedDto>();
        }
    }
}
