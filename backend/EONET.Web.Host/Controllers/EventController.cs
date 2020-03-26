using EONET.Application.Events;
using EONET.Application.Events.Dto;
using EONET.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NFS20.Web.Controllers
{
    [ApiController]
    [Route("api/Event")]
    public class EventController : Controller
    {
        private readonly IEventAppService _eventAppService;
        public EventController(IEventAppService eventAppService)
        {
            _eventAppService = eventAppService;
        }

        [HttpGet("GetById/{EventId}")]
        public async Task<ActionResult<EventResultCompletedDto>> GetById(string EventId)
        {
            return await _eventAppService.GetEntityByIdAsync(EventId);
        }

        [HttpPost("GetAll")]
        public async Task<ActionResult<PagedResultDto<EventResultListDto>>> GetAll([FromBody] PagedRequestDto pagedRequestDto = null)
        {
            return await _eventAppService.GetAllAsync(pagedRequestDto);
        }
    }
}