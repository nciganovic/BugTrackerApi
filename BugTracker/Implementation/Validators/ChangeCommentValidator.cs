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
    public class ChangeCommentValidator : AbstractValidator<ChangeCommentDto>
    {
        private readonly BugTrackerContext _context;

        public ChangeCommentValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Text)
             .MaximumLength(300);

            RuleFor(x => x.ApplicationUserId)
              .Must(x => UserExists(x))
              .WithMessage("User with id = {PropertyValue} doesn't exist.");

            RuleFor(x => x.TicketId)
              .Must(x => TicketExist(x))
              .WithMessage("Ticket with id = {PropertyValue} doesn't exist.");
        }

        private bool UserExists(int? id)
        {
            if (id != null) 
            { 
                if (_context.ApplicaitonUsers.Find(id) != null)
                {
                    return true;
                }

                return false;
            }

            return true;
        }

        private bool TicketExist(int? id)
        {
            if (id != null) 
            { 
                if (_context.Tickets.Find(id) != null)
                {
                    return true;
                }

                return false;
            }

            return true;
        }
    }
}
