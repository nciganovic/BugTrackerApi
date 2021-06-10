using Application.Commands.CommentCommands;
using Application.Dto;
using Application.Exceptions;
using Application.Queries.CommentQueries;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.CommentQueries
{
    public class EfGetOneCommentQuery : BaseUseCase, IGetOneCommentQuery
    {
        private readonly IMapper _mapper;

        public EfGetOneCommentQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Get one comment";

        public GetCommentDto Execute(int request)
        {
            Comment comment = context.Comments.Find(request);


            return _mapper.Map<Comment, GetCommentDto>(comment);
        }
    }
}
