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
    public class AddProjectValidator : AbstractValidator<AddProjectDto>
    {
        private BugTrackerContext _context;

        public AddProjectValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Must(x => !IsNameAlreadyTaken(x))
                .WithMessage("Project with name = '{PropertyValue}' already exists");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(150);
        }

        private bool IsNameAlreadyTaken(string name)
        {
            if (_context.Projects.FirstOrDefault(x => x.Name == name) != null)
            {
                return true;
            }

            return false;
        }
    }
}
