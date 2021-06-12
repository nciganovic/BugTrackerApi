using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Ticket;

namespace Application.Dto
{
    public class AddTicketDto
    {
        public int? OriginalTicketId { get; set; }
        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }

        public TicketType Type { get; set; }
        public int IssuerId { get; set; }
        public int DeveloperId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}
