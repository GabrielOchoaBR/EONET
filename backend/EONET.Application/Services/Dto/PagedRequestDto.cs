namespace EONET.Application.Services.Dto
{
    public class PagedRequestDto
    {
        public string userFilters { get; set; }
        public string orderBy { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
    }
}
