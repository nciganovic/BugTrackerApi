using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public List<CompanyApplicationUser> CompanyApplicaitonUsers { get; set; }
        public List<ProjectApplicationUser> ProjectApplicaitonUsers { get; set; }
        public List<Ticket> IssuerTickets { get; set; }
        public List<Ticket> DeveloperTickets { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
