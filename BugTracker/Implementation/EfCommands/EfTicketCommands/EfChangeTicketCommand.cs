using Application.Commands.ApplicationUserCommands;
using Application.Commands.TicketCommands;
using Application.Exceptions;
using Application.Queries.ApplicationUserQueries;
using Application.Queries.TicketQueries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfTicketCommands
{
    public class EfChangeTicketCommand : BaseUseCase, IChangeTicketCommand
    {

        public EfChangeTicketCommand(BugTrackerContext context) : base(context)
        {
        }

        public int Id => 84;

        public string Name => "Change ticket";

        public void Execute(Ticket request)
        {
            Ticket item = context.Tickets.Find(request.Id);

            if (item == null)
                throw new EntityNotFoundException(request.Id, "Ticket");

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.Tickets.Attach(request);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
