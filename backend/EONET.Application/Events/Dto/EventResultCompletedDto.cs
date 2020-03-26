using System.Collections.Generic;

namespace EONET.Application.Events.Dto
{
    public class EventResultCompletedDto
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }

        public List<EventCategoryResultCompletedDto> categories { get; set; }
        public List<EventSourceResultCompletedDto> sources { get; set; }
        public List<GeometryResultCompletedDto> geometries { get; set; }
    }
}
