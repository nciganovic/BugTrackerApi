using Application.Commands.AttachmentCommands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfAttachmentCommands
{
    public class EfChangeAttachmentCommand : IChangeAttachmentCommand
    {
        private readonly BugTrackerContext _context;
        public EfChangeAttachmentCommand(BugTrackerContext context)
        {
            _context = context;
        }

        public int Id => 43;

        public string Name => "Change attachment command";

        public void Execute(Attachment request)
        {
            var item = _context.Attachments.Find(request.Id);

            if (request.Name != null) 
            {
                item.Name = request.Name;
            }

            if (request.Path != null) {
                item.Path = request.Path;
            }

            item.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
