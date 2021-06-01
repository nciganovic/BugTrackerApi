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
    public class AddProjectApplicationUserValidator : AbstractValidator<AddProjectApplicationUserDto>
    {
        private BugTrackerContext _context;

        public AddProjectApplicationUserValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.ProjectId)
                .NotEmpty()
                .Must(x => ProjectExists(x))
                .WithMessage("Project with id = '{PropertyValue}' doesn't exist.");

            RuleFor(x => x.ApplicationUserId)
                .NotEmpty()
                .Must(x => ApplicationUserExists(x))
                .WithMessage("ApplicationUser with id = '{PropertyValue}' doesn't exist.");

            RuleFor(x => x.ProjectId)
                .Must((dto, projectId) => !ProjectApplicationUserAlreadyExist(dto.ProjectId, dto.ApplicationUserId))
                .WithMessage("Entity with given projectId and applicationUserId already exist.");
        }

        private bool ProjectExists(int id) 
        {
            if (_context.Projects.Find(id) != null) 
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

        private bool ProjectApplicationUserAlreadyExist(int projectId, int applicationUserId) 
        {
            if (_context.ProjectApplicationUsers
                .Where(x => x.ProjectId == projectId
                && x.ApplicationUserId == applicationUserId)
                .FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }
    }
}
