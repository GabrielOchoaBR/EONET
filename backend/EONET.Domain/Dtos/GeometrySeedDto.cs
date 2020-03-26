using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace EONET.Domain.Dtos
{
    public class GeometrySeedDto
    {
        public DateTime date { get; set; }
        public string type { get; set; }
        public object coordinates { get; set; }
    }
}