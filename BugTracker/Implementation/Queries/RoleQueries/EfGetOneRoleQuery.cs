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
using Application.Queries.RoleQueries;
using Implementation.EfCommands;

namespace Implementation.Queries.RoleQueries
{
    public class EfGetOneRoleQuery : BaseCommands, IGetOneRoleQuery
    {
        public EfGetOneRoleQuery(BugTrackerContext context) : base(context)
        {
            
        }

        public int Id => 30;

        public string Name => "Get one role";

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
