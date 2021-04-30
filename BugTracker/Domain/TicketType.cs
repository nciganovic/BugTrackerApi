﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TicketType : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ticket> Tickets { get; set; }
    }
}
