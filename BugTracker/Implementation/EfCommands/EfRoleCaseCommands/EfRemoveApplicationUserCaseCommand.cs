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
    public class EfRemoveApplicationUserCaseCommand : IRemoveRoleCaseCommand
    {
        private readonly BugTrackerContext _context;

        public EfRemoveApplicationUserCaseCommand(BugTrackerContext context)
        {
            _context = context;
        }

        public int Id => 39;

        public string Name => "Remove applicationUser case command";

        public void Execute(RoleUserCase request)
        {
            _context.Remove(request);
            _context.SaveChanges();
        }
    }
}
