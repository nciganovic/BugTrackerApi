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
    public class EfAddApplicationUserCaseCommand : BaseUseCase, IAddRoleCaseCommand
    {

        public EfAddApplicationUserCaseCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 63;

        public string Name => "Add ApplicationUser case command";

        public void Execute(RoleUserCase request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}
