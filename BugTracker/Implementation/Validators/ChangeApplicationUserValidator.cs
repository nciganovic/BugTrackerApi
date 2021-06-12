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
    public class ChangeApplicationUserValidator : AbstractValidator<ChangeApplicationUserDto>
    {
        private BugTrackerContext _context;

        public ChangeApplicationUserValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => UserExists(x))
                .WithMessage("User with id = {PropertyValue} doesn't exist");

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
                .Must(x => !IsEmailAlreadyTaken(x))
                .WithMessage("Email {PropertyValue} is already taken");

            RuleFor(x => x.RoleId)
                .Must(x => RoleExists(x))
                .WithMessage("Role with id = '{PropertyValue}' doesn't exist");
        }

        private bool IsEmailAlreadyTaken(string email)
        {
            if (_context.ApplicaitonUsers.Any(x => x.Email == email))
            {
                return true;
            }

            return false;
        }

        private bool UserExists(int id) {
            if (_context.ApplicaitonUsers.Find(id) != null) {
                return true;
            }

            return false;
        }

        private bool RoleExists(int roleId)
        {
            if (_context.Roles.FirstOrDefault(x => x.Id == roleId) != null)
            {
                return true;
            }

            return false;
        }
    }

   
}
