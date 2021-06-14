using Application.Commands.RoleCaseCommands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfRoleCaseCommands
{
    public class EfRemoveApplicationUserCaseCommand : BaseUseCase, IRemoveRoleCaseCommand
    {

        public EfRemoveApplicationUserCaseCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 39;

        public string Name => "Remove applicationUser case command";

        public void Execute(RoleUserCase request)
        {
            context.Remove(request);
            context.SaveChanges();
        }
    }
}
