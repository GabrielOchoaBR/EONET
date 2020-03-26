using System.ComponentModel.DataAnnotations.Schema;

namespace EONET.Domain.Entities
{
    public class EventSource
    {
        public string EventId { get; set; }
        [NotMapped]
        public virtual Event Event { get; set; }

        public string SourceId { get; set; }
        public virtual Source Source { get; set; }
    }
}
