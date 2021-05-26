using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Company : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CompanyApplicationUserRole> CompanyApplicaitonUsers { get; set; }
        public List<Project> Projects { get; set; }
    }
}
