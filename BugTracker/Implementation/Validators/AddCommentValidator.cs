using Application.Dto;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class AddCommentValidator : AbstractValidator<AddCommentDto>
    {
        private readonly BugTrackerContext _context;

        public AddCommentValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Text)
              .NotEmpty()
              .MaximumLength(300);

            RuleFor(x => x.ApplicationUserId)
              .NotEmpty()
              .Must(x => UserExists(x))
              .WithMessage("User with id = {PropertyValue} doesn't exist.");

            RuleFor(x => x.TicketId)
              .NotEmpty()
              .Must(x => TicketExist(x))
              .WithMessage("Ticket with id = {PropertyValue} doesn't exist.");
        }

        private bool UserExists(int id)
        {
            if (_context.ApplicaitonUsers.Find(id) != null)
            {
                return true;
            }

            return false;
        }

        private bool TicketExist(int id)
        {
            if (_context.Tickets.Find(id) != null)
            {
                return true;
            }

            return false;
        }
    }
}
