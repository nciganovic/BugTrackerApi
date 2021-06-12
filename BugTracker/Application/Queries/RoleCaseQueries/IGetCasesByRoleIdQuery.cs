using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.RoleCaseQueries
{
    public interface IGetCasesByRoleIdQuery : IQuery<int, IEnumerable<int>>
    {

    }
}
