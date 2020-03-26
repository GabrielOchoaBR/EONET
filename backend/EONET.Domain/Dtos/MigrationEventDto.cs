using System.Collections.Generic;

namespace EONET.Domain.Dtos
{
    public class MigrationEventDto
    {
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public ICollection<EventSeedDto> events { get; set; }
    }
}
