using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Attachment : BaseEntity
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }

        public Ticket Ticket { get; set; }
    }
}
