using Application.Commands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands
{
    public class TicketCommands : BaseCommands, ITicketCommands
    {
        public TicketCommands(BugTrackerContext context) : base(context)
        {

        }

        public void Create(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        public Ticket Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> Read()
        {
            throw new NotImplementedException();
        }

        public Ticket Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
