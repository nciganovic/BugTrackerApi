using Application.Dto;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ApplicationUserQueries
{
    public interface IGetApplicationUsersQuery : IQuery<ApplicationUserSearch, IEnumerable<ApplicationUserDto>>
    {
    }
}
