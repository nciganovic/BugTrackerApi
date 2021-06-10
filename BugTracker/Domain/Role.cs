using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } //Admin, ProjectManager, Developer, Submitter
        public ICollection<CompanyApplicationUserRole> CompanyApplicationUsers { get; set; } = new HashSet<CompanyApplicationUserRole>();
    }
}
