using Application.Dto;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.RoleQueries
{
    public interface IGetRolesQuery : IQuery<RoleSearch, IEnumerable<GetRoleDto>>
    {

    }
}
