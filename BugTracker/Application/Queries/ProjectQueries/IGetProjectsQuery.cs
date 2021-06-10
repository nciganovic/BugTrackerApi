using Application.Dto;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ProjectQueries
{
    public interface IGetProjectsQuery : IQuery<ProjectSearch, IEnumerable<GetProjectDto>>
    {
    }
}
