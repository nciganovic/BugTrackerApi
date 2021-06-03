using Application.Commands.CompanyCommands;
using Application.Dto;
using Application.Queries.CompanyQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
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
        private IMapper _mapper;

        public EfGetCompaniesQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
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

            query = query.SkipItems(request.Page, request.ItemsPerPage);

            return query.Select(_mapper.Map<Company, CompanyDto>).ToList();
        }
    }
}
