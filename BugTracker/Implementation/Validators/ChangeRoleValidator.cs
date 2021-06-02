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
    public class ChangeRoleValidator : AbstractValidator<ChangeRoleDto>
    {
        private BugTrackerContext _context;

        public ChangeRoleValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Must((dto, roleName) => !RoleExists(dto.Id, dto.Name))
                .WithMessage("Role with name = '{PropertyValue}' already exists");
        }

        private bool RoleExists(int id, string roleName)
        {
            if (_context.Roles.Where(x => x.Name == roleName && x.Id != id)
                .FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }
    }
}
