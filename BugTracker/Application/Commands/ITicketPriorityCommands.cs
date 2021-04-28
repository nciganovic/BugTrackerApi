using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ITicketPriorityCommands
    {
        public void Create(TicketPriority ticketPriority);
        public IEnumerable<TicketPriority> Read();
        public TicketPriority Read(int id);
        public void Update(TicketPriority ticketPriority);
        public TicketPriority Delete(int id);
    }
}
