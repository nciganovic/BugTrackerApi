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
        public ICollection<CompanyApplicationUserRole> CompanyApplicaitonUsers { get; set; } = new HashSet<CompanyApplicationUserRole>();
        public ICollection<Project> Projects { get; set; } = new HashSet<Project>();
    }
}
