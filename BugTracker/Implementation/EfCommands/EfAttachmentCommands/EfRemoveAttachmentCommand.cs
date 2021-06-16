using Application.Commands.AttachmentCommands;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfAttachmentCommands
{
    public class EfRemoveAttachmentCommand : BaseUseCase, IRemoveAttachmentCommand
    {

        public EfRemoveAttachmentCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 26;

        public string Name => "Remove attachment command";

        public void Execute(int request)
        {
            var item = context.Attachments.Find(request);

            if (item == null)
            {
                throw new EntityNotFoundException(request, "Attachment");
            }

            item.DeletedAt = DateTime.Now;
            //context.Attachments.Remove(item);
            context.SaveChanges();
        }
    }
}
