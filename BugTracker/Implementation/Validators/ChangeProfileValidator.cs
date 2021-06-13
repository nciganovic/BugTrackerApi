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
    public class ChangeProfileValidator : AbstractValidator<ChangeProfileDto>
    {
        private BugTrackerContext _context;

        public ChangeProfileValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
                .MaximumLength(30);

            RuleFor(x => x.LastName)
                .MaximumLength(30);

            RuleFor(x => x.Email)
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .MaximumLength(20);

            RuleFor(x => x.Email)
                .Must((dto, x) => !IsEmailAlreadyTaken(dto))
                .WithMessage("Email {PropertyValue} is already taken");
        }

        private bool IsEmailAlreadyTaken(ChangeProfileDto dto)
        {
            if (_context.ApplicaitonUsers.Any(x => x.Email == dto.Email &&  x.Id != dto.Id))
            {
                return true;
            }

            return false;
        }
    }
}
