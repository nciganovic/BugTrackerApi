using Application.Commands.ApplicationUserCommands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfApplicationUserCommands
{
    public class EfRemoveApplicationUserCommand : BaseCommands, IRemoveApplicationUserCommand
    {
        public EfRemoveApplicationUserCommand(BugTrackerContext bugTrackerContext) : base(bugTrackerContext)
        {

        }

        public void Execute(int request)
        {
            ApplicationUser user = context.ApplicaitonUsers.Find(request);

            if (user == null)
                throw new EntityNotFoundException();

            user.DeletedAt = DateTime.Now;

            context.ApplicaitonUsers.Update(user);
            context.SaveChanges();
        }
    }
}
