using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using DataAccess;
using FluentValidation;

namespace Implementation.Validators
{
    public class AddCompanyApplicationUserRoleValidator : AbstractValidator<AddCompanyApplicationUserRoleDto>
    {
        private readonly BugTrackerContext _context;

        public AddCompanyApplicationUserRoleValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.CompanyId)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .Must(x => CompanyExists(x))
              .WithMessage("Company with id = {PropertyValue} doesn't exist.");

            RuleFor(x => x.ApplicationUserId)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .Must(x => ApplicationUserExists(x))
              .WithMessage("User with id = {PropertyValue} doesn't exist.");

            RuleFor(x => x.RoleId)
              .Cascade(CascadeMode.Stop)
              .NotEmpty()
              .Must(x => RoleExists(x))
              .WithMessage("Role with id = {PropertyValue} doesn't exist.");

            RuleFor(x => x.CompanyId)
                .Must((dto, companyId) => !AlreadyExist(companyId, dto.ApplicationUserId))
                .WithMessage("Entity already exists, duplicates are not allowed.");
        }

        private bool CompanyExists(int id)
        {
            if (_context.Companies.Find(id) != null)
            {
                return true;
            }

            return false;
        }

        private bool ApplicationUserExists(int id)
        {
            if (_context.ApplicaitonUsers.Find(id) != null)
            {
                return true;
            }

            return false;
        }

        private bool RoleExists(int id)
        {
            if (_context.Roles.Find(id) != null)
            {
                return true;
            }

            return false;
        }

        private bool AlreadyExist(int companyId, int applicationUserId) {
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
