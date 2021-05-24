using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.RoleQueries
{
    public interface IGetOneRoleQuery : IQuery<int, RoleDto>
    {
    }
}
