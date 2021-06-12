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
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<ProjectApplicationUser> ProjectApplicationUsers { get; set; } = new HashSet<ProjectApplicationUser>();
        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
