using Application.Commands.ApplicationUserCommands;
using Application.Commands.TicketCommands;
using Application.Dto;
using Application.Queries.TicketQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.TicketCommandsQueries
{
    public class EfGetTicketsQuery : BaseUseCase, IGetTicketsQuery
    {
        private readonly IMapper _mapper;

        public EfGetTicketsQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 36;

        public string Name => "Get tickets";

        public IEnumerable<TicketDto> Execute(TicketSearch request)
        {
            var query = context.Tickets.AsQueryable();

            if (request.Title != null) {
                query = query.Where(x => x.Title.ToLower().Contains(request.Title.ToLower()));
            }

            if (request.Priority != null) {
                query = query.Where(x => (int)x.Priority == request.Priority);
            }

            if (request.Status != null)
            {
                query = query.Where(x => (int)x.Status == request.Status);
            }

            if (request.Type != null)
            {
                query = query.Where(x => (int)x.Type == request.Type);
            }

            if (request.Issuer != null) { 
                query = query.Where(x => x.IssuerId == request.Issuer);
            }

            if (request.Developer != null)
            {
                query = query.Where(x => x.IssuerId == request.Developer);
            }

            if (request.OnlyActive != null)
            {
                if (request.OnlyActive == true)
                {
                    query = query.Where(x => x.DeletedAt == null);
                }
            }

            return query.Select(x => _mapper.Map<Ticket, TicketDto>(x)).ToList();
        }
    }
}
