using Application.Commands.ApplicationUserCommands;
using Application.Commands.ProjectApplicationUserCommands;
using Application.Commands.ProjectCommands;
using Application.Dto;
using Application.Queries.ApplicationUserQueries;
using Application.Queries.ProjectApplicationUserQueries;
using Application.Queries.ProjectQueries;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ProjectApplicationUserQueries
{
    public class EfGetApplicationUsersForProjectQuery : BaseCommands, IGetApplicationUsersForProjectQuery
    {
        private readonly IMapper _mapper;
        private readonly IGetOneProjectQuery _getOneProjectQuery;
        private readonly IGetOneApplicationUserQuery _getOneApplicationUserCommand;

        public EfGetApplicationUsersForProjectQuery(BugTrackerContext context, IGetOneProjectQuery getOneProjectQuery, IMapper mapper,
            IGetOneApplicationUserQuery getOneApplicationUserCommand) : base(context)
        {
            _getOneProjectQuery = getOneProjectQuery;
            _mapper = mapper;
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
        }

        public int Id => 21;

        public string Name => "Get applicationUsers for project";

        public IEnumerable<ApplicationUserDto> Execute(int request)
        {
            if (request != 0)
            {
                _getOneProjectQuery.Execute(request);
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
