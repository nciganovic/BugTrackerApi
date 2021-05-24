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

namespace Implementation.EfCommands.EfApplicationUserCommands
{
    public class EfGetOneApplicationUserCommand : BaseCommands, IGetOneApplicationUserQuery
    {
        private IMapper _mapper;

        public EfGetOneApplicationUserCommand(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 10;

        public string Name => "Get one applicationUser";

        public ApplicationUserDto Execute(int request)
        {
            ApplicationUser user = context.ApplicaitonUsers.Find(request);

            if (user == null) {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<ApplicationUser, ApplicationUserDto>(user);
        }
    }
}
