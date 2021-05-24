using Application.Commands.ApplicationUserCommands;
using Application.Commands.CompanyApplicationUserCommands;
using Application.Dto;
using Application.Exceptions;
using Application.Queries.CompanyApplicationUserQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfCompanyApplicationUserCommands
{
    public class EfGetOneCompanyApplicationUserCommand : BaseCommands, IGetOneCompanyApplicationUserQuery
    {
        private readonly IMapper _mapper;

        public EfGetOneCompanyApplicationUserCommand(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Get one company applicationUser";

        public CompanyApplicationUserDto Execute(CompanyApplicationUserSearch request)
        {
            CompanyApplicationUser item = context.CompanyApplicationUsers
                .Where(x => x.ApplicationUserId == request.ApplicationUserId 
                && x.CompanyId == request.CompanyId)
                    .FirstOrDefault();

            if (item == null) {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<CompanyApplicationUser, CompanyApplicationUserDto>(item);
        }
    }
}
