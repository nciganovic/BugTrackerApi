using Application.Commands.CompanyCommands;
using Application.Dto;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfCompanyCommands
{
    public class EfGetOneCompanyCommand : BaseCommands, IGetOneCompanyCommand
    {
        public EfGetOneCompanyCommand(BugTrackerContext context) : base(context)
        {

        }

        public CompanyDto Execute(int request)
        {
            var company = context.Companies.Find(request);

            if (company == null)
                throw new EntityNotFoundException();

            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
            };
        }
    }
}
