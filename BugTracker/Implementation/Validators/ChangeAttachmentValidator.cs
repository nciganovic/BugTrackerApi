using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using DataAccess;
using FluentValidation;

namespace Implementation.Validators
{
    public class ChangeAttachmentValidator : AbstractValidator<ChangeAttachmentDto>
    {

        private readonly BugTrackerContext _context;

        public ChangeAttachmentValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => AttachmentExists(x))
                .WithMessage("Attachment with id = '{PropertyValue}' doesn't exist'.");

            RuleFor(x => x.TicketId)
                .Must(x => TicketExists(x))
                .WithMessage("Ticket with id = '{PropertyValue}' doesn't exist'.");
        }

        private bool TicketExists(int id)
        {
            if (_context.Tickets.Find(id) != null)
            {
                return true;
            }

            return false;
        }

        private bool AttachmentExists(int id)
        {
            if (_context.Attachments.Find(id) != null)
            {
                return true;
            }

            return false;
        }
    }
}
