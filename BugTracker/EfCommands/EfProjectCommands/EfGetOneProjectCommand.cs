using Application.Commands.ProjectCommands;
using Application.Dto;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfProjectCommands
{
    public class EfGetOneProjectCommand : BaseCommands, IGetOneProjectCommand
    {
        public EfGetOneProjectCommand(BugTrackerContext context) : base(context)
        {

        }

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
