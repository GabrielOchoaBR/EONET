namespace EONET.Domain.Entities
{
    public class EventCategory
    {
        public string EventId { get; set; }
        public virtual Event Event { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
