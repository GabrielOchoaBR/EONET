using EONET.Application.Services.Dto;
using EONET.Domain.Entities;
using EONET.EntityFrameworkCore.EntityFrameworkCore;
using EONET.Managers.Base;
using System.Threading.Tasks;

namespace EONET.Managers.Events
{
    public class EventManager : ManagerBase<Event, string>, IEventManager
    {
        public EventManager(EONETDbContext context) : base(context)
        {
        }

        public override async Task<Event> GetEntityByIdAsync(string id)
        {
            return await base.GetEntityByIdAsync(x => x.id == id, "categories.Category, sources.Source, geometries");
        }
        public override async Task<PagedResult<Event>> GetAllAsync(PagedRequest input)
        {
            return await base.GetAllAsync(input, "id DESC");
        }
    }
}
