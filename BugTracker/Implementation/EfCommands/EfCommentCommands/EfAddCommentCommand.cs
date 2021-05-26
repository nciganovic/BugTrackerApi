using Application.Commands.ApplicationUserCommands;
using Application.Commands.CommentCommands;
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

namespace Implementation.EfCommands.EfCommentCommands
{
    public class EfAddCommentCommand : BaseCommands, IAddCommentCommand
    {
        private readonly IGetOneApplicationUserQuery _getOneApplicationUserCommand;
        private readonly IGetOneTicketQuery _getOneTicketCommand;

        public EfAddCommentCommand(BugTrackerContext context,
            IGetOneApplicationUserQuery getOneApplicationUserCommand,
            IGetOneTicketQuery getOneTicketCommand) : base(context)
        {
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
            _getOneTicketCommand = getOneTicketCommand;
        }

        public int Id => 1;

        public string Name => "Add comment";

        public void Execute(Comment request)
        {
            request.CreatedAt = DateTime.Now;
            context.Comments.Add(request);
            context.SaveChanges();
        }
    }
}
