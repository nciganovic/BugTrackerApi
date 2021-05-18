using Application.Commands.ApplicationUserCommands;
using Application.Commands.TicketCommands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Ticket;

namespace EfCommands.EfTicketCommands
{
    public class EfAddTicketCommand : BaseCommands, IAddTicketCommand
    {
        private readonly IGetOneTicketCommand _getOneTicketCommand;
        private readonly IGetOneApplicationUserCommand _getOneApplicationUserCommand;

        public EfAddTicketCommand(BugTrackerContext context
            , IGetOneTicketCommand getOneTicketCommand
            , IGetOneApplicationUserCommand getOneApplicationUserCommand) : base(context)
        {
            _getOneTicketCommand = getOneTicketCommand;
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
        }

        public void Execute(Ticket request)
        {
            if (request.OriginalTicketId != null) {
                _getOneTicketCommand.Execute((int)request.OriginalTicketId);
            }

            if (request.DeveloperId != 0)
            {
                _getOneApplicationUserCommand.Execute(request.DeveloperId);
            }
            else {
                throw new Exception("DeveloperId is required field and cannot be 0");
            }

            if (request.IssuerId != 0)
            {
                _getOneApplicationUserCommand.Execute(request.IssuerId);
            }
            else {
                throw new Exception("IssuerId is required field and cannot be 0");
            }


            context.Tickets.Add(request);
            context.SaveChanges();
        }
    }
}
