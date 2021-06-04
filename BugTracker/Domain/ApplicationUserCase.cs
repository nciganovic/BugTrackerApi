using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ApplicationUserCase : BaseEntity
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int UseCaseId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
