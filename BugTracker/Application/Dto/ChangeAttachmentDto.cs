using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class ChangeAttachmentDto
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
