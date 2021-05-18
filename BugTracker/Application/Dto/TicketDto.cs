using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Ticket;

namespace Application.Dto
{
    public class TicketDto
    {
        public int Id { get; set; }

        public int? OriginalTicketId { get; set; }
        public Ticket OriginalTicket { get; set; }

        [Range(0, 3)]
        public TicketPriority Priority { get; set; }

        [Range(0, 4)]
        public TicketStatus Status { get; set; }

        [Range(0, 1)]
        public TicketType Type { get; set; }


        public int IssuerId { get; set; }
        public ApplicationUser Issuer { get; set; }

        public int DeveloperId { get; set; }
        public ApplicationUser Developer { get; set; }

        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Ticket> TicketHistories { get; set; }
    }
}
