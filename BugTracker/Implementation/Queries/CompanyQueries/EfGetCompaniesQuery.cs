using Application.Commands.CompanyCommands;
using Application.Dto;
using Application.Queries.CompanyQueries;
using Application.Searches;
using DataAccess;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.CompanyQueries
{
    public class EfGetCompaniesQuery : BaseUseCase,  IGetCompaniesQuery
    {
        public EfGetCompaniesQuery(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 17;

        public string Name => "Get companies";

        public IEnumerable<CompanyDto> Execute(CompanySearch request)
        {
            var query = context.Companies.AsQueryable();

            if (request.Name != null)
            {
                query = query.Where(x => x.Name
                .ToLower()
                .Contains(request.Name.ToLower()));
            }

            if (request.OnlyActive.HasValue)
            {
                if (request.OnlyActive == true)
                {
                    query = query.Where(x => x.DeletedAt == null);
                }
            }

            return query.Select(x => new CompanyDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
