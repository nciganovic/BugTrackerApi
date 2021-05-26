using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public string Salt { get; set; }

        public List<CompanyApplicationUserRole> CompanyApplicaitonUsers { get; set; }
        public List<ProjectApplicationUser> ProjectApplicaitonUsers { get; set; }
        public List<Ticket> IssuerTickets { get; set; }
        public List<Ticket> DeveloperTickets { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
