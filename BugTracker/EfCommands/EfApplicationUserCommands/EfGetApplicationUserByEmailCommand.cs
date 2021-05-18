using Application.Commands.ApplicationUserCommands;
using Application.Dto;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;

namespace EfCommands.EfApplicationUserCommands
{
    public class EfGetApplicationUserByEmailCommand : BaseCommands, IGetApplicationUserByEmailCommand
    {
        private readonly IMapper _mapper;

        public EfGetApplicationUserByEmailCommand(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public ApplicationUserDto Execute(string request)
        {
            ApplicationUser user = context.ApplicaitonUsers.Where(x => x.Email == request).FirstOrDefault();

            if (user == null) {
                throw new EntityNotFoundException();
            }

            ApplicationUserDto applicationUserDto = _mapper.Map<ApplicationUserDto>(user);
            return applicationUserDto;
        }
    }
}
