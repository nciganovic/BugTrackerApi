﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class CompanyApplicationUserSearch
    {
        public int ApplicationUserId { get; set; }
        public int CompanyId { get; set; }
        public int? Page { get; set; }
        public int? ItemsPerPage { get; set; }
    }
}
