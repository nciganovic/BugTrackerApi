using Application.Dto;
using Application.Queries.ProjectApplicationUserQueries;
using AutoMapper;
using DataAccess;
using Implementation.EfCommands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ProjectApplicationUserQueries
{
    public class EfGetProjectsForApplicationUserQuery : BaseUseCase, IGetProjectsForApplicationUserQuery
    {
        private readonly IMapper _mapper;

        public int Id => 42;

        public string Name => "Get projects for application user";

        public EfGetProjectsForApplicationUserQuery(BugTrackerContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public IEnumerable<GetProjectDto> Execute(int search)
        {
            var query = context.ProjectApplicationUsers.AsQueryable();
            query = query.Where(x => x.ApplicationUserId == search && x.DeletedAt == null && x.ApplicationUser.DeletedAt == null)
                .Include(x => x.ApplicationUser).Include(x => x.Project);
            return query.Select(x => _mapper.Map<GetProjectDto>(x.Project));
        }
    }
}
