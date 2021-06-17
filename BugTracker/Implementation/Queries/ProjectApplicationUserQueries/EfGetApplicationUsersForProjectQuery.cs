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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ProjectApplicationUserQueries
{
    public class EfGetApplicationUsersForProjectQuery : BaseUseCase, IGetApplicationUsersForProjectQuery
    {
        private readonly IMapper _mapper;

        public EfGetApplicationUsersForProjectQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 41;

        public string Name => "Get applicationUsers for project";

        public IEnumerable<GetApplicationUserDto> Execute(int request)
        {
            var query = context.ProjectApplicationUsers.AsQueryable();
            query = query.Where(x => x.ProjectId == request && x.Project.DeletedAt == null)
                .Include(x => x.Project).Include(x => x.ApplicationUser);
            return query.Select(x => _mapper.Map<GetApplicationUserDto>(x.ApplicationUser)); 
        }
    }
}
