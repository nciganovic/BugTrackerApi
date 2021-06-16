using Application.Commands.TicketCommands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfTicketCommands
{
    public class EfRemoveTicketCommand : BaseUseCase, IRemoveTicketCommand
    {
        public EfRemoveTicketCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 85;

        public string Name => "Remove ticket";

        public void Execute(int request)
        {
            Ticket ticket = context.Tickets.Find(request);

            if (ticket == null)
                throw new EntityNotFoundException(request, "Ticket");

            ticket.DeletedAt = DateTime.Now;

            context.Tickets.Update(ticket);
            context.SaveChanges();
        }
    }
}
