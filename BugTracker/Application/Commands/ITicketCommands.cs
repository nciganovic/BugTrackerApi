using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ITicketCommands
    {
        public void Create(Ticket ticket);
        public IEnumerable<Ticket> Read();
        public Ticket Read(int id);
        public void Update(Ticket ticket);
        public Ticket Delete(int id);
    }
}
