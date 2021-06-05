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
    public class AddApplicationUserCaseValidator : AbstractValidator<AddApplicationUserCaseDto>
    {
        private readonly BugTrackerContext _context;

        public AddApplicationUserCaseValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.ApplicationUserId)
                .NotNull()
                .DependentRules(() =>
                {
                    RuleFor(x => x.ApplicationUserId)
                        .Must(x => ApplicationUserExists((int)x))
                        .WithMessage("ApplicationUser with id = '{PropertyValue}' doesn't exist.")
                        .DependentRules(() => 
                        {
                            RuleFor(x => x.UseCaseId)
                                .NotNull()
                                .DependentRules(() =>
                                {
                                    RuleFor(x => x.UseCaseId)
                                        .NotNull()
                                        .Must((dto, caseId) => !ApplicationUserCaseExists((int)dto.ApplicationUserId, (int)dto.UseCaseId))
                                        .WithMessage("Entity already exists.");
                                });
                        });
                        
                });
                
        }

        private bool ApplicationUserExists(int id) 
        {
            if (_context.ApplicaitonUsers.Find(id) != null) 
            {
                return true;            
            }

            return false;
        }

        private bool ApplicationUserCaseExists(int id, int caseId)
        {
            if (_context.ApplicationUserCases
                .FirstOrDefault(x => x.ApplicationUserId == id 
                && x.UseCaseId == caseId) != null)
            {
                return true;
            }

            return false;
        }
    }
}
