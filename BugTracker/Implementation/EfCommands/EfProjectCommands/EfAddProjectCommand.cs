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
    public class EfAddProjectCommand : BaseUseCase, IAddProjectCommand
    {
        public int Id => 23;

        public string Name => "Add project";

        public EfAddProjectCommand(BugTrackerContext context) : base(context)
        {

        }

        public void Execute(Project request)
        {
            request.CreatedAt = DateTime.Now;
            context.Add(request);
            context.SaveChanges();
        }
    }
}
