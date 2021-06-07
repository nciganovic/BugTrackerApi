using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interfaces;
using Application.Searches;
using Domain;

namespace Application.Queries.UseCaseQueries
{
    public interface IGetUseCaseLogsQuery : IQuery<UseCaseLogSearch, IEnumerable<UseCaseLog>>
    {
    }
}
