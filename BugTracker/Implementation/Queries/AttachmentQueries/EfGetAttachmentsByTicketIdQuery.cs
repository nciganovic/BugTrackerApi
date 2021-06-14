using Application.Dto;
using Application.Queries.AttachmentQueries;
using AutoMapper;
using DataAccess;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.AttachmentQueries
{
    public class EfGetAttachmentsByTicketIdQuery : BaseUseCase, IGetAttachmentsByTicketIdQuery
    {
        private readonly IMapper _mapper;

        public EfGetAttachmentsByTicketIdQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 45;

        public string Name => "Get attachments by ticket id query";

        public IEnumerable<GetAttachmentDto> Execute(int search)
        {
            var items = context.Attachments.Where(x => x.TicketId == search && x.DeletedAt == null);
            return items.Select(x => _mapper.Map<GetAttachmentDto>(x)).ToList();
        }
    }
}
