using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Application.Dto
{
    public class AddAttachmentDto
    {
        public int TicketId { get; set; }
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
