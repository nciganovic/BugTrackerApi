using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ProjectApplicationUser : BaseEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
