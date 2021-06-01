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
    public class AddCompanyValidator : AbstractValidator<AddCompanyDto>
    {
        private readonly BugTrackerContext _context;

        public AddCompanyValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Must(x => !CompanyExists(x))
                .WithMessage(x => $"Company with name = '{x.Name}' already exist.");
        }

        private bool CompanyExists(string name)
        {
            if (_context.Companies.Where(x => x.Name == name).FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }
    }
}
