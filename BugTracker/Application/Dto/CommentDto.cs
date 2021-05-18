using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
