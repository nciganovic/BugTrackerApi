using Application.Commands.CommentCommands;
using Application.Dto;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Implementation.EfCommands.EfCommentCommands
{
    public class EfGetCommentsCommand : BaseCommands, IGetCommentsCommand
    {
        private readonly IMapper _mapper;

        public EfGetCommentsCommand(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public IEnumerable<CommentDto> Execute(CommentSearch request)
        {
            var query = context.Comments.Include(x => x.ApplicationUser).AsQueryable();

            if (request.Keyword != null) {
                query = query.Where(x => x.Text.ToLower().Contains(request.Keyword.ToLower()));
            }

            if (request.OnlyActive != null) {
                if (request.OnlyActive == true)
                    query = query.Where(x => x.DeletedAt == null);
            }

            return query.Select(x => _mapper.Map<Comment, CommentDto>(x)).ToList();
        }
    }
}
