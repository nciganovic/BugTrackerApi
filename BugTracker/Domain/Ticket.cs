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

        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }
        public TicketType Type { get; set; }


        public int IssuerId { get; set; }
        public ApplicationUser Issuer { get; set; }

        public int DevloperId { get; set; }
        public ApplicationUser Developer { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Ticket> TicketHistories { get; set; }

        public enum TicketPriority
        {
            None,
            Low,
            Medium,
            High
        }

        public enum TicketStatus
        {
            New,
            Open,
            InProgess,
            Resolved,
            AdditionalInfo
        }

        public enum TicketType
        {
            Bug,
            Feature
        }
    }
}
