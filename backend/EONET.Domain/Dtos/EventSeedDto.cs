using EONET.Domain.Entities;
using System.Collections.Generic;

namespace EONET.Domain.Dtos
{
    public class EventSeedDto
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
        public ICollection<CategorySeedDto> categories { get; set; }
        public ICollection<SourceSeedDto> sources { get; set; }
        public ICollection<GeometrySeedDto> geometries { get; set; }

        public ICollection<EventCategory> CategoriesConverter()
        {
            ICollection<EventCategory> result = new List<EventCategory>();

            foreach (CategorySeedDto item in this.categories)
            {
                result.Add(new EventCategory()
                {
                    Category = new Category()
                    {
                        id = item.id,
                        title = item.title
                    }
                });
            }

            return result;
        }

        public ICollection<EventSource> SourcesConverter()
        {
            ICollection<EventSource> result = new List<EventSource>();

            foreach (SourceSeedDto item in this.sources)
            {
                result.Add(new EventSource()
                {
                    Source = new Source()
                    {
                        id = item.id,
                        url = item.url
                    }
                });
            }

            return result;
        }

        public ICollection<Geometry> GeometryConverter()
        {
            ICollection<Geometry> result = new List<Geometry>();

            foreach (GeometrySeedDto item in this.geometries)
            {
                string coordinates = string.Empty;

                coordinates = item.coordinates.ToString().Replace("\r\n", "").Replace(" ", "").Replace("[", "").Replace("]", "");

                if (item.type.ToUpper() == "POINT")
                {
                    string[] cRearrange = coordinates.Split(",");

                    if (cRearrange.Length == 2)
                        coordinates = string.Concat(cRearrange[1], ",", cRearrange[0]);
                }

                result.Add(new Geometry()
                {
                    date = item.date,
                    coordinates = coordinates,
                    type = item.type
                });
            }

            return result;
        }
    }
}
