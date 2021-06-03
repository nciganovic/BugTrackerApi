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
    public class EfAddRoleCommand : BaseCommands, IAddRoleCommand
    {
        public EfAddRoleCommand(BugTrackerContext context) : base(context)
        {
                
        }

        public int Id => 28;

        public string Name => "Add role";

        public void Execute(Role request)
        {
            request.CreatedAt = DateTime.Now;
            context.Add(request);
            context.SaveChanges();
        }
    }
}
