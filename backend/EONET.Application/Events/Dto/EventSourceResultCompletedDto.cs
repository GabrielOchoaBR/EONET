namespace EONET.Application.Events.Dto
{
    public class EventSourceResultCompletedDto
    {
        public string SourceId { get; set; }
        public SourceResultCompletedDto Source { get; set; }
    }
}
