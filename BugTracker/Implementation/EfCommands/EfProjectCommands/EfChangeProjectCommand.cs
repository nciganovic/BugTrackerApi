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
    public class EfChangeProjectCommand : BaseUseCase, IChangeProjectCommand
    {
        public int Id => 54;

        public string Name => "Change project";

        public EfChangeProjectCommand(BugTrackerContext context) : base(context)
        {

        }

        public void Execute(Project request)
        {
            Project item = context.Projects.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.Projects.Attach(request);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
