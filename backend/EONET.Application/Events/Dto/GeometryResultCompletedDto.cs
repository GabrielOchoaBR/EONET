using System;

namespace EONET.Application.Events.Dto
{
    public class GeometryResultCompletedDto
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public string coordinates { get; set; }
        public string EventId { get; set; }
    }
}