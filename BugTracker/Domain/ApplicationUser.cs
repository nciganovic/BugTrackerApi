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
        public List<CompanyApplicationUser> CompanyApplicaitonUsers { get; set; }
        public List<ProjectApplicationUser> ProjectApplicaitonUsers { get; set; }
        public List<Ticket> IssuerTickets { get; set; }
        public List<Ticket> DeveloperTickets { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
