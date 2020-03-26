using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EONET.Domain.Entities
{
    public class Geometry
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public string coordinates { get; set; }
        public string EventId { get; set; }
        [NotMapped]
        public Event Event { get; set; }

    }
}