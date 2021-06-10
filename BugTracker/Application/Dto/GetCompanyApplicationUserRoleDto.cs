using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class GetCompanyApplicationUserRoleDto
    {
        public int CompanyId { get; set; }
        public int ApplicationUserId { get; set; }

        public int RoleId { get; set; }
    }
}
