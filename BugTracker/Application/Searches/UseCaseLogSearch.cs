using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Searches
{
    public class UseCaseLogSearch
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UseCaseNameKeyword { get; set; }
        public string DataKeyword { get; set; }
        public string ActorKeyword { get; set; }
    }
}
