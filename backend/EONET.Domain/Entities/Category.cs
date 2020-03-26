using System.Collections.Generic;

namespace EONET.Domain.Entities
{
    public class Category
    {
        public int id { get; set; }
        public string title { get; set; }

        public virtual ICollection<EventCategory> Events { get; set; }
    }
}
