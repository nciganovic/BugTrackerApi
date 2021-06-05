using Application.Commands.ApplicationUserCaseCommands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfApplicationUserCaseCommands
{
    public class EfAddApplicationUserCaseCommand : IAddApplicationUserCaseCommand
    {

        private readonly BugTrackerContext _bugTrackerContext;
        public EfAddApplicationUserCaseCommand(BugTrackerContext bugTrackerContext)
        {
            _bugTrackerContext = bugTrackerContext;
        }

        public int Id => 38;

        public string Name => "Add ApplicationUser case command";

        public void Execute(ApplicationUserCase request)
        {
            _bugTrackerContext.Add(request);
            _bugTrackerContext.SaveChanges();
        }
    }
}
