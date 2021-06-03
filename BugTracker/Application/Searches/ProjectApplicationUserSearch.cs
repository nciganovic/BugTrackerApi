using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class ProjectApplicationUserSearch
    {
        public int ProjectId { get; set; }
        public int ApplicationUserId { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}
