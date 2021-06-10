using Application.Commands.CompanyCommands;
using Application.Dto;
using Application.Exceptions;
using Application.Queries.CompanyQueries;
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
    public class EfGetOneCompanyQuery : BaseUseCase, IGetOneCompanyQuery
    {
        private IMapper _mapper;

        public EfGetOneCompanyQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 18;

        public string Name => "Get one company";

        public GetCompanyDto Execute(int request)
        {
            var company = context.Companies.Find(request);


            return _mapper.Map<Company, GetCompanyDto>(company);
        }
    }
}
