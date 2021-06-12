using Application.Dto;
using Application.Extensions;
using Application.Queries.AttachmentQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfAttachmentCommands
{
    public class EfGetAttachmentsQuery : IGetAttachmentsQuery
    {
        private readonly BugTrackerContext _context;
        private readonly IMapper _mapper;

        public EfGetAttachmentsQuery(BugTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 51;

        public string Name => "Get attachments query";

        public IEnumerable<GetAttachmentDto> Execute(AttachmentSearch search)
        {
            var query = _context.Attachments.AsQueryable();

            if (search.NameKeyword != null)
            {
                query = query.Where(x => x.Name.Contains(search.NameKeyword));
            }

            if (search.TicketId != null)
            {
                query = query.Where(x => x.TicketId == (int)search.TicketId);
            }

            if (search.PathKeyword != null)
            {
                query = query.Where(x => x.Path.Contains(search.PathKeyword));
            }

            if (search.OnlyActive != null)
            {
                if (search.OnlyActive == true)
                {
                    query = query.Where(x => x.DeletedAt == null);
                }
                
            }

            query = query.SkipItems(search.Page, search.ItemsPerPage);

            return query.Select(x => _mapper.Map<GetAttachmentDto>(x)).ToList();
        }
    }
}
