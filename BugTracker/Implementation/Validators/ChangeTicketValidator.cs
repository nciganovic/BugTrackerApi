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
    public class ChangeTicketValidator : AbstractValidator<ChangeTicketDto>
    {
        private BugTrackerContext _context;

        public ChangeTicketValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => TicketExists(x))
                .WithMessage("Ticket with id = '{PropertyValue}' doesn't exists");

            RuleFor(x => x.OriginalTicketId)
                .Must(x => TicketExists(x))
                .WithMessage("Ticket with id = '{PropertyValue}' doesn't exists");

            RuleFor(x => (int)x.Priority)
                .InclusiveBetween(0, 3);

            RuleFor(x => (int)x.Status)
                .InclusiveBetween(0, 4);

            RuleFor(x => (int)x.Type)
                .InclusiveBetween(0, 1);

            RuleFor(x => x.IssuerId)
                .Must(x => ApplicationUserExists(x))
                .WithMessage("ApplicationUser with id = '{PropertyValue}' doesn't exists");

            RuleFor(x => x.DeveloperId)
                .Must(x => ApplicationUserExists(x))
                .WithMessage("ApplicationUser with id = '{PropertyValue}' doesn't exists");

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.ProjectId)
                .Must(x => ProjectExists(x))
                .WithMessage("Project with id = '{PropertyValue}' doesn't exists");
        }

        private bool TicketExists(int? ticketId)
        {
            if (ticketId != null)
            {
                if (_context.Tickets.Find(ticketId) != null)
                {
                    return true;
                }

                return false;
            }

            return true;
        }

        private bool ApplicationUserExists(int ticketId)
        {
            if (_context.ApplicaitonUsers.Find(ticketId) != null)
            {
                return true;
            }

            return false;
        }

        private bool ProjectExists(int projectId)
        {
            if (_context.Projects.Find(projectId) != null)
            {
                return true;
            }

            return false;
        }
    }
}
