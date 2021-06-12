using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApplicationUser : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<ProjectApplicationUser> ProjectApplicaitonUsers { get; set; } = new HashSet<ProjectApplicationUser>();
        public ICollection<Ticket> IssuerTickets { get; set; } = new HashSet<Ticket>();
        public ICollection<Ticket> DeveloperTickets { get; set; } = new HashSet<Ticket>();
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public ICollection<RoleUserCase> RoleCases { get; set; } = new HashSet<RoleUserCase>();
    }
}
