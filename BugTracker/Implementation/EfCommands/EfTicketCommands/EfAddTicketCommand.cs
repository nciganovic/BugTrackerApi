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
        private readonly IGetOneTicketQuery _getOneTicketQuery;
        private readonly IGetOneApplicationUserQuery _getOneApplicationUserCommand;

        public EfAddTicketCommand(BugTrackerContext context
            , IGetOneTicketQuery getOneTicketCommand
            , IGetOneApplicationUserQuery getOneApplicationUserCommand) : base(context)
        {
            _getOneTicketQuery = getOneTicketCommand;
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
        }

        public int Id => 33;

        public string Name => "Add ticket";

        public void Execute(Ticket request)
        {
            if (request.OriginalTicketId != null) {
                _getOneTicketQuery.Execute((int)request.OriginalTicketId);
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
