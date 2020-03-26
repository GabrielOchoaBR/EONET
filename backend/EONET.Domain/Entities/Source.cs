using System.Collections.Generic;

namespace EONET.Domain.Entities
{
    public class Source
    {
        public string id { get; set; }
        public string url { get; set; }

        public virtual ICollection<EventSource> Events { get; set; }
    }
}
