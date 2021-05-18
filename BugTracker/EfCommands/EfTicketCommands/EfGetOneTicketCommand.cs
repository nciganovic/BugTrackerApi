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

namespace EfCommands.EfTicketCommands
{
    public class EfGetOneTicketCommand : BaseCommands, IGetOneTicketCommand
    {
        private readonly IMapper _mapper;

        public EfGetOneTicketCommand(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

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
