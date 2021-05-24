using Application.Commands.ProjectCommands;
using Application.Dto;
using Application.Exceptions;
using Application.Queries.ProjectQueries;
using DataAccess;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ProjectCommandsQueries
{
    public class EfGetOneProjectQuery : BaseCommands, IGetOneProjectQuery
    {
        public EfGetOneProjectQuery(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 25;

        public string Name => "Get one project";

        public ProjectDto Execute(int request)
        {
            var project = context.Projects.Find(request);

            if (project == null)
                throw new EntityNotFoundException();

            return new ProjectDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Company = project.Company,
                CompanyId = project.CompanyId,
                ProjectApplicationUsers = project.ProjectApplicationUsers
            };
        }
    }
}
