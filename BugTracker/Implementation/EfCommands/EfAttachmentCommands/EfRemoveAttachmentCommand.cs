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
    public class EfRemoveAttachmentCommand : IRemoveAttachmentCommand
    {
        private readonly BugTrackerContext _context; 

        public EfRemoveAttachmentCommand(BugTrackerContext context)
        {
            _context = context;
        }

        public int Id => 44;

        public string Name => "Remove attachment command";

        public void Execute(int request)
        {
            var item = _context.Attachments.Find(request);

            if (item == null)
            {
                throw new EntityNotFoundException();
            }

            item.DeletedAt = DateTime.Now;
            //_context.Attachments.Remove(item);
            _context.SaveChanges();
        }
    }
}
