using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class TicketSearch
    {
        public string Title { get; set; }
        public int? Priority { get; set; }
        public int? Status { get; set; }
        public int? Type { get; set; }
        public int? Issuer { get; set; }
        public int? Developer { get; set; }
        public bool? OnlyActive { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}
