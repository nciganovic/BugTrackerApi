using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ApplicationUserId { get; set; }
        public int TicketId { get; set; }
    }
}
