using Application.Commands.ApplicationUserCommands;
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
    public class EfChangeTicketCommand : BaseCommands, IChangeTicketCommand
    {
        private readonly IGetOneTicketCommand _getOneTicketCommand;
        private readonly IGetOneApplicationUserCommand _getOneApplicationUserCommand;

        public EfChangeTicketCommand(BugTrackerContext context
            , IGetOneTicketCommand getOneTicketCommand
            , IGetOneApplicationUserCommand getOneApplicationUserCommand) : base(context)
        {
            _getOneTicketCommand = getOneTicketCommand;
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
        }

        public void Execute(Ticket request)
        {
            Ticket item = context.Tickets.Find(request.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (request.OriginalTicketId != null)
            {
                _getOneTicketCommand.Execute((int)request.OriginalTicketId);
            }

            if (request.DeveloperId != 0)
            {
                _getOneApplicationUserCommand.Execute(request.DeveloperId);
            }
            else
            {
                throw new Exception("DeveloperId is required field and cannot be 0");
            }

            if (request.IssuerId != 0)
            {
                _getOneApplicationUserCommand.Execute(request.IssuerId);
            }
            else
            {
                throw new Exception("IssuerId is required field and cannot be 0");
            }

            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.Tickets.Attach(request);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
