using Application.Commands.ApplicationUserCommands;
using Application.Commands.CommentCommands;
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

namespace Implementation.EfCommands.EfCommentCommands
{
    public class EfChangeCommentCommand : BaseCommands, IChangeCommentCommand
    {
        private readonly IGetOneApplicationUserQuery _getOneApplicationUserCommand;
        private readonly IGetOneTicketQuery _getOneTicketCommand;

        public EfChangeCommentCommand(BugTrackerContext context,
            IGetOneApplicationUserQuery getOneApplicationUserCommand,
            IGetOneTicketQuery getOneTicketCommand) : base(context)
        {
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
            _getOneTicketCommand = getOneTicketCommand;
        }

        public int Id => 2;

        public string Name => "Change comment";

        public void Execute(Comment request)
        {
            Comment item = context.Comments.Find(request.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (request.ApplicationUserId != 0)
            {
                _getOneApplicationUserCommand.Execute(request.ApplicationUserId);
            }
            else
            {
                throw new Exception("ApplicationUserId is required field and cannot be 0");
            }

            if (request.TicketId != 0)
            {
                _getOneTicketCommand.Execute(request.TicketId);
            }
            else
            {
                throw new Exception("TicketId is required field and cannot be 0");
            }

            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.Comments.Attach(request);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
