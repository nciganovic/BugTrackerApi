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
    public class ChangeProjectValidator : AbstractValidator<ChangeProjectDto>
    {
        private BugTrackerContext _context;

        public ChangeProjectValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Must((dto, x) => !IsNameAlreadyTaken(dto))
                .WithMessage("Project with name = '{PropertyValue}' already exists"); ;

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(150);
        }


        private bool IsNameAlreadyTaken(ChangeProjectDto dto)
        {
            if (_context.Projects.FirstOrDefault(x => x.Name == dto.Name && x.Id != dto.Id) != null)
            {
                return true;
            }

            return false;
        }

    }
}
