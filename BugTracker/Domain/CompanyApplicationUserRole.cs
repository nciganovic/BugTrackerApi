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
        public Company Company { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }    
    }
}
