using Application.Commands.ProjectCommands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfProjectCommands
{
    public class EfRemoveProjectCommand : BaseCommands, IRemoveProjectCommand
    {
        public EfRemoveProjectCommand(BugTrackerContext context) : base(context)
        {

        }

        public void Execute(int request)
        {
            Project item = context.Projects.Find(request);

            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.Projects.Update(item);
            context.SaveChanges();
        }
    }
}
