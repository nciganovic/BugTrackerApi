using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ChangeCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ApplicationUserId { get; set; }
        public int? TicketId { get; set; }
    }
}
