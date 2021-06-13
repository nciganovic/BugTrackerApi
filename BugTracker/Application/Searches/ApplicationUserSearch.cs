using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class ApplicationUserSearch
    {
        public string FirstNameKeyword { get; set; }
        public string LastNameKeyword { get; set; }
        public string EmailKeyword { get; set; }
        public int? RoleId { get; set; }
        public bool? OnlyActive { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}
