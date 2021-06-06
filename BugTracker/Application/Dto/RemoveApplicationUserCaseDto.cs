using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class RemoveApplicationUserCaseDto
    {
        public int ApplicationUserId { get; set; }
        public int UseCaseId { get; set; }
    }
}
