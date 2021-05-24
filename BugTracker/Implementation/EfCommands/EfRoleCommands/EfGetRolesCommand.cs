using Application.Commands.Roles;
using Application.Dto;
using Application.Queries.RoleQueries;
using Application.Searches;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfRoleCommands
{
    public class EfGetRolesCommand : BaseCommands, IGetRolesQuery
    {
        public EfGetRolesCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 31;

        public string Name => "Get roles";

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
