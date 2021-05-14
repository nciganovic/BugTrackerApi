using Application.Commands.ProjectCommands;
using Application.Dto;
using Application.Searches;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfProjectCommands
{
    public class EfGetProjectsCommand : BaseCommands, IGetProjectsCommand
    {
        public EfGetProjectsCommand(BugTrackerContext context) : base(context)
        {

        }

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

            return query.Select(x => new ProjectDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Company = x.Company,
                CompanyId = x.CompanyId,
                ProjectApplicationUsers = x.ProjectApplicationUsers
            }).ToList();
        }
    }
}
