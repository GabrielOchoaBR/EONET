using System;
using System.Collections.Generic;
using System.Text;

namespace EONET.Application.Services.Dto
{
    public class PagedRequest
    {
        public string userFilters { get; set; }
        public string orderBy { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
    }
}
