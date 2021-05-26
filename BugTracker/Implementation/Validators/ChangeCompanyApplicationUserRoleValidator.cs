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
    public class ChangeCompanyApplicationUserRoleValidator : AbstractValidator<ChangeCompanyApplicationUserRoleDto>
    {
        private readonly BugTrackerContext _context;

        public ChangeCompanyApplicationUserRoleValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.CompanyId)
                .Must((dto, companyId) => AlreadyExist(companyId, dto.ApplicationUserId))
                .WithMessage("Entity with given companyId and applicationUserId not found.")
                .DependentRules(() =>
                {
                    RuleFor(x => x.RoleId)
                      .Cascade(CascadeMode.Stop)
                      .NotEmpty()
                      .Must(x => RoleExists(x))
                      .WithMessage("Role with id = {PropertyValue} doesn't exist.");
                });
        }

        private bool RoleExists(int id)
        {
            if (_context.Roles.Find(id) != null)
            {
                return true;
            }

            return false;
        }

        private bool AlreadyExist(int companyId, int applicationUserId)
        {
            if (_context.CompanyApplicationUserRoles
                .Where(x => x.CompanyId == companyId
                && x.ApplicationUserId == applicationUserId)
                .FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }
    }
}
