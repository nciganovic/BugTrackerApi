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
    public class EfChangeRoleCommand : BaseCommands, IChangeRoleCommand
    {
        public EfChangeRoleCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 29;

        public string Name => "Change role";

        public void Execute(Role request)
        {
            Role item = context.Roles.Find(request.Id);

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.Roles.Attach(request);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
