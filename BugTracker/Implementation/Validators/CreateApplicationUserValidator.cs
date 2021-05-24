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
    public class CreateApplicationUserValidator : AbstractValidator<CreateApplicationUserDto>
    {
        private BugTrackerContext _context;

        public CreateApplicationUserValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .MinimumLength(8)
                .MaximumLength(20);

            RuleFor(x => x.Email)
                .Must(x => !IsEmailAlreadyTaken(x))
                .WithMessage("Email {PropertyValue} is already taken");
        
        }

        private bool IsEmailAlreadyTaken(string email)
        {
            if (_context.ApplicaitonUsers.Any(x => x.Email == email))
            {
                return true;
            }

            return false;
        }
    }
}
