using Application.Commands.ApplicationUserCommands;
using Application.Dto;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using AutoMapper;
using Application.Queries.ApplicationUserQueries;
using Implementation.EfCommands;

namespace Implementation.Queries.ApplicationUserQueries
{
    public class EfGetOneApplicationUserQuery : BaseUseCase, IGetOneApplicationUserQuery
    {
        private IMapper _mapper;

        public EfGetOneApplicationUserQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Get one applicationUser";

        public GetApplicationUserDto Execute(int request)
        {
            ApplicationUser user = context.ApplicaitonUsers.Find(request);

            if (user == null) {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<ApplicationUser, GetApplicationUserDto>(user);
        }
    }
}
