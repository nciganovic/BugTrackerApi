using Application.Commands.CompanyCommands;
using Application.Dto;
using Application.Exceptions;
using Application.Queries.CompanyQueries;
using DataAccess;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.CompanyQueries
{
    public class EfGetOneCompanyQuery : BaseCommands, IGetOneCompanyQuery
    {
        public EfGetOneCompanyQuery(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 18;

        public string Name => "Get one company";

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
