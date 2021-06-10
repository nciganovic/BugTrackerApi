using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CompanyApplicationUserRole : BaseEntity
    {
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }    
    }
}
