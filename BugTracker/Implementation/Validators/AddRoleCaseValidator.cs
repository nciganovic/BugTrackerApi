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
    public class AddRoleCaseValidator : AbstractValidator<AddRoleCaseDto>
    {
        private readonly BugTrackerContext _context;

        public AddRoleCaseValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.RoleId)
                .NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.RoleId)
                        .Must(x => RoleExists((int)x))
                        .WithMessage("ApplicationUser with id = '{PropertyValue}' doesn't exist.")
                        .DependentRules(() => 
                        {
                            RuleFor(x => x.UseCaseId)
                                .NotNull()
                                .DependentRules(() =>
                                {
                                    RuleFor(x => x.UseCaseId)
                                        .NotNull()
                                        .Must((dto, caseId) => !RoleCaseExists((int)dto.RoleId, (int)dto.UseCaseId))
                                        .WithMessage("Entity already exists.");
                                });
                        });
                        
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

        private bool RoleCaseExists(int id, int caseId)
        {
            if (_context.RoleCases
                .FirstOrDefault(x => x.Id == id 
                && x.UseCaseId == caseId) != null)
            {
                return true;
            }

            return false;
        }
    }
}
