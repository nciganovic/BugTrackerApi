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

namespace EfCommands.EfApplicationUserCommand
{
    public class EfGetOneApplicationUserCommand : BaseCommands, IGetOneApplicationUserCommand
    {
        private IMapper _mapper;

        public EfGetOneApplicationUserCommand(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

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
