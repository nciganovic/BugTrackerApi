using Application.Commands.Roles;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfRoleCommands
{
    public class EfAddRoleCommand : BaseCommands, IAddRoleCommand
    {
        public EfAddRoleCommand(BugTrackerContext context) : base(context)
        {
                
        }

        public void Execute(Role request)
        {
            if (IsNameAlreadyTaken(request.Name))
            {
                throw new EntityAlreadyExists();
            }

            context.Add(request);
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
