using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ProjectDto
    {
        public int Id { get; set; }

        [Required]
        public int CompanyId { get; set; }
        
        public Company Company { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        
        public List<ProjectApplicationUser> ProjectApplicationUsers { get; set; }
    }
}
