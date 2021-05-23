using Application.Commands.ApplicationUserCommands;
using Application.Commands.CommentCommands;
using Application.Commands.TicketCommands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfCommentCommands
{
    public class EfAddCommentCommand : BaseCommands, IAddCommentCommand
    {
        private readonly IGetOneApplicationUserCommand _getOneApplicationUserCommand;
        private readonly IGetOneTicketCommand _getOneTicketCommand;

        public EfAddCommentCommand(BugTrackerContext context,
            IGetOneApplicationUserCommand getOneApplicationUserCommand,
            IGetOneTicketCommand getOneTicketCommand) : base(context)
        {
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
            _getOneTicketCommand = getOneTicketCommand;
        }

        public void Execute(Comment request)
        {
            if (request.ApplicationUserId != 0)
            {
                _getOneApplicationUserCommand.Execute(request.ApplicationUserId);
            }
            else {
                throw new Exception("ApplicationUserId is required field and cannot be 0");
            }

            if (request.TicketId != 0)
            {
                _getOneTicketCommand.Execute(request.TicketId);
            }
            else {
                throw new Exception("TicketId is required field and cannot be 0");
            }

            context.Comments.Add(request);
            context.SaveChanges();
        }
    }
}
