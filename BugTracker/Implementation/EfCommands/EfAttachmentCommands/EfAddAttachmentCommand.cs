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
    public class EfAddAttachmentCommand : IAddAttachmentCommand
    {
        private readonly BugTrackerContext _context;

        public EfAddAttachmentCommand(BugTrackerContext context)
        {
            _context = context;
        }

        public int Id => 42;

        public string Name => "Add attachment command";

        public void Execute(Attachment request)
        {
            request.CreatedAt = DateTime.Now;
            _context.Attachments.Add(request);
            _context.SaveChanges();
        }
    }
}
