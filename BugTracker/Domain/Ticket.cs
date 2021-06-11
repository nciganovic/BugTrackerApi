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
        public virtual Ticket OriginalTicket { get; set; }

        public TicketPriority Priority { get; set; }
        public TicketStatus Status { get; set; }
        public TicketType Type { get; set; }


        public int IssuerId { get; set; }
        public virtual ApplicationUser Issuer { get; set; }

        public int DeveloperId { get; set; }
        public virtual ApplicationUser Developer { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        public ICollection<Ticket> TicketHistories { get; set; } = new HashSet<Ticket>();

        public ICollection<Attachment> Attachments { get; set; } = new HashSet<Attachment>();

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
