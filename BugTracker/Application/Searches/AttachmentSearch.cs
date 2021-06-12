using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class AttachmentSearch
    {
        public string NameKeyword { get; set; }
        public int? TicketId { get; set; }
        public string PathKeyword { get; set; }
        public bool? OnlyActive { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}
