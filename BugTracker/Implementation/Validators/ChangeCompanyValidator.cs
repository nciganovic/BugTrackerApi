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
    public class ChangeCompanyValidator : AbstractValidator<ChangeCompanyDto>
    {
        private BugTrackerContext _context; 
        
        public ChangeCompanyValidator(BugTrackerContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Must(x => CompanyExists(x))
                .WithMessage(x => $"Company with id = '{x.Id}' doesn't exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Must((dto, name) => !CompanyExists(dto.Id, name))
                .WithMessage(x => $"Company with name = '{x.Name}' already exist.");

        }

        private bool CompanyExists(int id)
        {
            if (_context.Companies.Find(id) != null)
            {
                return true;
            }

            return false;
        }

        private bool CompanyExists(int id, string name)
        {
            if (_context.Companies.Where(x => x.Name == name && x.Id != id).FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }
    }
}
