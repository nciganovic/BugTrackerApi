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
    public class AddRoleValidator : AbstractValidator<AddRoleDto>
    {
        private BugTrackerContext _context;

        public AddRoleValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Must(x => !RoleExists(x))
                .WithMessage("Role with name = '{PropertyValue}' already exists");
        }

        private bool RoleExists(string roleName)
        {
            if (_context.Roles.Where(x => x.Name == roleName).FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }
    }
}
