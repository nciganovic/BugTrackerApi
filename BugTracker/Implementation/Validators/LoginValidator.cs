using Application.Dto;
using Application.Hash;
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
               .WithMessage("User with email = {PropertyValue} doesn't exist.")
               .DependentRules(() => 
               {
                   RuleFor(x => x.Password)
                       .NotEmpty()
                       .Must((dto, x) => CheckPassword(dto))
                       .WithMessage("Password is invalid.");
               });
            
        }

        private bool UserExists(string email)
        {
            if (_context.ApplicaitonUsers.Where(x => x.Email == email).FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }

        private bool CheckPassword(LoginDto dto) {
            var user = _context.ApplicaitonUsers.Where(x => x.Email == dto.Email).FirstOrDefault();

            if (user != null) 
            {
                if (Password.VerifyPassword(dto.Password, user.Password, user.Salt))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
