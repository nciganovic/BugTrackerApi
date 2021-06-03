using Application.Commands.ApplicationUserCommands;
using Application.Commands.TicketCommands;
using Application.Queries.ApplicationUserQueries;
using Application.Queries.TicketQueries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Ticket;

namespace Implementation.EfCommands.EfTicketCommands
{
    public class EfAddTicketCommand : BaseCommands, IAddTicketCommand
    {

        public EfAddTicketCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 33;

        public string Name => "Add ticket";

        public void Execute(Ticket request)
        {
            request.CreatedAt = DateTime.Now;
            context.Tickets.Add(request);
            context.SaveChanges();
        }
    }
}
