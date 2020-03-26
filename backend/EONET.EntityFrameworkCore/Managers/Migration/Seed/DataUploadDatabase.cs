using EONET.Domain.Dtos;
using EONET.Domain.Entities;
using EONET.EntityFrameworkCore.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EONET.Managers.Migration.Seed
{
    public class DataUploadDatabase
    {
        public DataUploadDatabase() { }

        public void Upload(EONETDbContext appContext, MigrationEventDto migrationEventDto, bool closed)
        {
            foreach (EventSeedDto eventSeedDto in migrationEventDto.events)
            {
                if (appContext.Set<Event>().Find(eventSeedDto.id) != null)
                    continue;

                List<EventCategory> eventCategories = (List<EventCategory>)eventSeedDto.CategoriesConverter();
                List<EventSource> eventSources = (List<EventSource>)eventSeedDto.SourcesConverter();
                List<Geometry> geometries = (List<Geometry>)eventSeedDto.GeometryConverter();


                foreach (EventCategory eventCategory in eventCategories)
                {
                    Category category = appContext.Set<Category>().Find(eventCategory.Category.id);

                    if (category != null)
                    {
                        eventCategory.CategoryId = eventCategory.Category.id;
                        eventCategory.EventId = eventSeedDto.id;
                        eventCategory.Category = null;
                    }
                }

                foreach (EventSource eventSource in eventSources)
                {
                    Source category = appContext.Set<Source>().Find(eventSource.Source.id);

                    if (category != null)
                    {
                        eventSource.SourceId = eventSource.Source.id;
                        eventSource.EventId = eventSeedDto.id;
                        eventSource.Source = null;
                    }
                }

                appContext.Set<Event>().Add(new Event()
                {
                    id = eventSeedDto.id,
                    title = eventSeedDto.title,
                    description = eventSeedDto.description,
                    link = eventSeedDto.link,
                    closed = closed,
                    categories = eventCategories,
                    sources = eventSources,
                    geometries = geometries
                }
                );

                appContext.SaveChanges();
            }
        }
    }
}
