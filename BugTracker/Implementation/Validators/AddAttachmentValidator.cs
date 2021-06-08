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
    public class AddAttachmentValidator : AbstractValidator<AddAttachmentDto>
    {
        private readonly BugTrackerContext _context;

        public AddAttachmentValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.TicketId)
                .Must(x => TicketExists(x))
                .WithMessage("Ticket with id = '{PropertyValue}' doesn't exist'.");

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.File)
                .NotNull();
        }

        private bool TicketExists(int id) 
        {
            if (_context.Tickets.Find(id) != null) 
            {
                return true;
            }

            return false;
        }
    }
}
