using Application.Commands.TicketCommands;
using Application.Dto;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Queries.TicketQueries;
using Implementation.EfCommands;

namespace Implementation.Queries.TicketCommandsQueries
{
    public class EfGetOneTicketQuery : BaseCommands, IGetOneTicketQuery
    {
        private readonly IMapper _mapper;

        public EfGetOneTicketQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 35;

        public string Name => "Get one ticket";

        public TicketDto Execute(int request)
        {
            Ticket item = context.Tickets.Find(request);

            if(item == null)
            {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<Ticket, TicketDto>(item);
        }
    }
}
