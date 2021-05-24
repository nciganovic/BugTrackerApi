using Application.Commands.Roles;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfRoleCommands
{
    public class EfRemoveRoleCommand : BaseCommands, IRemoveRoleCommand
    {
        public EfRemoveRoleCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 32;

        public string Name => "Remove role";

        public void Execute(int request)
        {
            Role item = context.Roles.Find(request);

            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.Roles.Update(item);
            context.SaveChanges();
        }
    }
}
