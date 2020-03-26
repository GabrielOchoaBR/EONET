using System.Collections.Generic;

namespace EONET.Domain.Entities
{
    public class Event
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public bool closed { get; set; }
        public virtual ICollection<EventCategory> categories { get; set; }
        public virtual ICollection<EventSource> sources { get; set; }
        public virtual ICollection<Geometry> geometries { get; set; }
    }
}
