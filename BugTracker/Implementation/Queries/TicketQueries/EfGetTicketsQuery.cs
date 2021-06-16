using Application.Commands.ApplicationUserCommands;
using Application.Commands.TicketCommands;
using Application.Dto;
using Application.Extensions;
using Application.Queries.TicketQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using Microsoft.EntityFrameworkCore;
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

        public int Id => 81;

        public string Name => "Get tickets";

        public IEnumerable<GetTicketDto> Execute(TicketSearch request)
        {
            var query = context.Tickets.Include(x => x.Comments).AsQueryable();

            ICollection<Comment> comments = query.First().Comments;

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

            query = query.SkipItems(request.Page, request.ItemsPerPage);

            return query.Select(x => _mapper.Map<Ticket, GetTicketDto>(x)).ToList();
        }
    }
}
