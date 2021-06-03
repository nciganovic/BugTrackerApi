using Application.Commands.ProjectCommands;
using Application.Dto;
using Application.Queries.ProjectQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ProjectCommandsQueries
{
    public class EfGetProjectsQuery : BaseUseCase, IGetProjectsQuery
    {
        private readonly IMapper _mapper;

        public EfGetProjectsQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 26;

        public string Name => "Get projects";

        public IEnumerable<ProjectDto> Execute(ProjectSearch request)
        {
            var query = context.Projects.AsQueryable();

            if (request.Name != null)
            {
                query = query.Where(x => x.Name
                .ToLower()
                .Contains(request.Name.ToLower()));
            }

            if (request.OnlyActive.HasValue)
            {
                if (request.OnlyActive == true)
                {
                    query = query.Where(x => x.DeletedAt == null);
                }
            }

            return query.Select(x => _mapper.Map<Project, ProjectDto>(x)).ToList();
        }
    }
}
