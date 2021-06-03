using Application.Commands.ApplicationUserCommands;
using Application.Commands.ProjectApplicationUserCommands;
using Application.Commands.ProjectCommands;
using Application.Queries.ApplicationUserQueries;
using Application.Queries.ProjectQueries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfProjectApplicationUserCommands
{
    public class EfAddProjectApplicationUserCommand : BaseUseCase, IAddProjectApplicationUserCommand
    {

        public EfAddProjectApplicationUserCommand(BugTrackerContext context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Add project applicationUser";

        public void Execute(ProjectApplicationUser request)
        {
            request.CreatedAt = DateTime.Now;
            context.ProjectApplicationUsers.Add(request);
            context.SaveChanges();
        }
    }
}
