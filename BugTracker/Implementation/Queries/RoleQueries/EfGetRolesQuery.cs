using Application.Commands.Roles;
using Application.Dto;
using Application.Extensions;
using Application.Queries.RoleQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.RoleQueries
{
    public class EfGetRolesQuery : BaseUseCase, IGetRolesQuery
    {
        private IMapper _mapper;

        public EfGetRolesQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 31;

        public string Name => "Get roles";

        public IEnumerable<GetRoleDto> Execute(RoleSearch request)
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

            query = query.SkipItems(request.Page, request.ItemsPerPage);

            return query.Select(x => _mapper.Map<Role, GetRoleDto>(x)).ToList();
        }
    }
}
