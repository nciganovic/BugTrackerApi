using Application.Dto;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.TicketQueries
{
    public interface IGetOneTicketQuery : IQuery<int, GetTicketDto>
    {
    }
}
