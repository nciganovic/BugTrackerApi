using Application.Commands.ProjectCommands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfProjectCommands
{
    public class EfRemoveProjectCommand : BaseUseCase, IRemoveProjectCommand
    {
        public EfRemoveProjectCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 55;

        public string Name => "Remove project";

        public void Execute(int request)
        {
            Project item = context.Projects.Find(request);

            if (item == null)
                throw new EntityNotFoundException(request, "Project");

            item.DeletedAt = DateTime.Now;

            context.Projects.Update(item);
            context.SaveChanges();
        }
    }
}
