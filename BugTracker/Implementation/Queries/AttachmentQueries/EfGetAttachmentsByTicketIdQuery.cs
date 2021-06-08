using Application.Dto;
using Application.Queries.AttachmentQueries;
using AutoMapper;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.AttachmentQueries
{
    public class EfGetAttachmentsByTicketIdQuery : IGetAttachmentsByTicketIdQuery
    {
        private readonly BugTrackerContext _context;
        private readonly IMapper _mapper;

        public EfGetAttachmentsByTicketIdQuery(BugTrackerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 45;

        public string Name => "Get attachments by ticket id query";

        public IEnumerable<GetAttachmentDto> Execute(int search)
        {
            var items = _context.Attachments.Where(x => x.TicketId == search);
            return items.Select(x => _mapper.Map<GetAttachmentDto>(x)).ToList();
        }
    }
}
