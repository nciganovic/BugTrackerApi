using Application.Commands.Roles;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.Roles
{
    public class EfChangeRoleCommand : BaseCommands, IChangeRoleCommand
    {
        public EfChangeRoleCommand(BugTrackerContext context) : base(context)
        {

        }

        public void Execute(Role request)
        {
            Role item = context.Roles.Find(request.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (IsNameAlreadyTaken(request.Name))
                throw new EntityAlreadyExists();

            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.Roles.Attach(request);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        private bool IsNameAlreadyTaken(string name)
        {
            if (context.Roles.Any(x => x.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
