using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ApplicationUserCaseQueries
{
    public interface IGetCasesByApplicationUserIdQuery : IQuery<int, IEnumerable<int>>
    {

    }
}
