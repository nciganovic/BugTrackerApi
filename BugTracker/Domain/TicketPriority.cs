using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TicketPriority : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
