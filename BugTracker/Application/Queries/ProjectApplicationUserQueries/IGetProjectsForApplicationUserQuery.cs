using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ProjectApplicationUserQueries
{
    public interface IGetProjectsForApplicationUserQuery : IQuery<int, IEnumerable<GetProjectDto>>
    {
    }
}
