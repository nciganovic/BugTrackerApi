using Application.Commands.ApplicationUserCommands;
using Application.Commands.ProjectApplicationUserCommands;
using Application.Commands.ProjectCommands;
using Application.Dto;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfProjectApplicationUserCommands
{
    public class EfGetApplicationUsersForProjectCommand : BaseCommands, IGetApplicationUsersForProjectCommand
    {
        private readonly IMapper _mapper;
        private readonly IGetOneProjectCommand _getOneProjectCommand;
        private readonly IGetOneApplicationUserCommand _getOneApplicationUserCommand;

        public EfGetApplicationUsersForProjectCommand(BugTrackerContext context, IGetOneProjectCommand getOneProjectCommand, IMapper mapper,
            IGetOneApplicationUserCommand getOneApplicationUserCommand) : base(context)
        {
            _getOneProjectCommand = getOneProjectCommand;
            _mapper = mapper;
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
        }

        public IEnumerable<ApplicationUserDto> Execute(int request)
        {
            if (request != 0)
            {
                _getOneProjectCommand.Execute(request);
            }
            else
            {
                throw new Exception("ProjectId is required field and cannot be 0");
            }

            var query = context.ProjectApplicationUsers.AsQueryable();
            query = query.Where(x => x.ProjectId == request);
            
            IEnumerable<ProjectApplicationUserDto> projectApplicationUserDtos = query.Select(x => _mapper.Map<ProjectApplicationUser, ProjectApplicationUserDto>(x));
            List<ApplicationUser> applicationUsers = new List<ApplicationUser>();

            foreach (var x in projectApplicationUserDtos) { 
                ApplicationUserDto applicationUserDto = _getOneApplicationUserCommand.Execute(x.ApplicationUserId);
                ApplicationUser applicationUser = _mapper.Map<ApplicationUserDto, ApplicationUser>(applicationUserDto);
                applicationUsers.Add(applicationUser);
            }
            
            return applicationUsers.Select(x => _mapper.Map<ApplicationUser, ApplicationUserDto>(x)).ToList();
        }
    }
}
