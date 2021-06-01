﻿using Application.Dto;
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

            RuleFor(x => x.CompanyId)
                .Must(x => CompanyExists(x))
                .WithMessage("Company with id = {PropertyValue} doesn't exist.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(30)
                .Must((dto, x) => !CompanyProjectNameExist(dto.CompanyId, dto.Name))
                .WithMessage("Project with name = {PropertyValue} already exists for given company."); ;

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(150);
        }

        private bool CompanyExists(int companyId) 
        {
            if (_context.Companies.Find(companyId) != null) 
            {
                return true;
            }

            return false;
        }

        private bool CompanyProjectNameExist(int companyId, string projectName)
        {
            if (_context.Projects
                .Where(x => x.CompanyId == companyId && x.Name == projectName)
                .FirstOrDefault() != null)
            {
                return true;
            }

            return false;
        }
    }
}
