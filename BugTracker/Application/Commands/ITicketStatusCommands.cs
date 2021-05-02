using Domain;
using System.Collections.Generic;

namespace Application.Commands
{
    public interface ITicketStatusCommands
    {
        public void Create(TicketStatus ticketStatus);
        public IEnumerable<TicketStatus> Read();
        public TicketStatus Read(int id);
        public void Update(TicketStatus ticketStatus);
        public TicketStatus Delete(int id);
    }
}
