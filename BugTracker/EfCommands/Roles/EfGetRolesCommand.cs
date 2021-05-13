using Application.Commands.Roles;
using Application.Dto;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.Roles
{
    public class EfGetRolesCommand : BaseCommands, IGetRolesCommand
    {
        public EfGetRolesCommand(BugTrackerContext context) : base(context)
        {

        }

        public IEnumerable<RoleDto> Execute(RoleSearch request)
        {
            var query = context.Roles.AsQueryable();

            if (request.Name != null) {
                query = query.Where(x => x.Name
                .ToLower()
                .Contains(request.Name.ToLower()));
            }

            if (request.OnlyActive.HasValue) {
                if (request.OnlyActive == true) { 
                    query = query.Where(x => x.DeletedAt == null);
                }
            }

            return query.Select(x => new RoleDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
