using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ITicketType
    {
        public void Create(TicketType ticketType);
        public IEnumerable<TicketType> Read();
        public TicketType Read(int id);
        public void Update(TicketType ticketType);
        public TicketType Delete(int id);
    }
}
