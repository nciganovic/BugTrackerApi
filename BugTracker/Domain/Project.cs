using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Project : BaseEntity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProjectApplicationUser> ProjectApplicationUsers { get; set; } = new HashSet<ProjectApplicationUser>();
    }
}
