using Application.Commands.CommentCommands;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfCommentCommands
{
    public class EfRemoveCommentCommand : BaseUseCase, IRemoveCommentCommand
    {
        public EfRemoveCommentCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 5;

        public string Name => "Remove comment";

        public void Execute(int request)
        {
            var item = context.Comments.Find(request);

            if (item == null) {
                throw new EntityNotFoundException();
            }

            item.DeletedAt = DateTime.Now;

            context.Comments.Update(item);
            context.SaveChanges();
        }
    }
}
