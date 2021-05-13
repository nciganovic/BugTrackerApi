using Application.Dto;
using Application.Exceptions;
using Application.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Roles;

namespace EfCommands
{
    public class EfGetOneRoleCommand : BaseCommands, IGetOneRoleCommand
    {
        public EfGetOneRoleCommand(BugTrackerContext context) : base(context)
        {
            
        }

        public RoleDto Execute(int request)
        {
            var role = context.Roles.Find(request);

            if (role == null)
                throw new EntityNotFoundException();

            return new RoleDto
            {
                Id = role.Id,
                Name = role.Name
            };
        }
    }
}
