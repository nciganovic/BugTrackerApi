using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class GetProjectApplicationUserDto
    {
        public int ProjectId { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
