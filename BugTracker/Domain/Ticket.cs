using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Ticket : BaseEntity
    {
        public int Id { get; set; }

        public int? OriginalTicketId { get; set; }
        public Ticket OriginalTicket { get; set; }

        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; }

        public int TicketStatusId { get; set; }
        public TicketStatus TicketStatus { get; set; }

        public int TicketPriorityId { get; set; }
        public TicketPriority TicketPriority { get; set; }

        public int IssuerId { get; set; }
        public ApplicationUser Issuer { get; set; }

        public int DevloperId { get; set; }
        public ApplicationUser Developer { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Ticket> TicketHistories { get; set; }

    }
}
