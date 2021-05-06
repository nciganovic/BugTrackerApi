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
        [Range(1, int.MaxValue)]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        
        public List<CompanyApplicationUser> CompanyApplicaitonUsers { get; set; }
        public List<ProjectApplicationUser> ProjectApplicaitonUsers { get; set; }
        public List<Ticket> IssuerTickets { get; set; }
        public List<Ticket> DeveloperTickets { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
