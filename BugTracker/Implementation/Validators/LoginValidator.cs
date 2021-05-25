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
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        private readonly BugTrackerContext _context;

        public LoginValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Email)
               .NotEmpty()
               .Must(x => UserExists(x))
               .WithMessage("User with email = {PropertyValue} doesn't exist.");

            RuleFor(x => x.Password)
               .NotEmpty();
        }

        private bool UserExists(string email)
        {
            if (_context.ApplicaitonUsers.Where(x => x.Email == email).FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }
    }
}
