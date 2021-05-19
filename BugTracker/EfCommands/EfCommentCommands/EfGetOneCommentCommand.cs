using Application.Commands.CommentCommands;
using Application.Dto;
using Application.Exceptions;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfCommentCommands
{
    public class EfGetOneCommentCommand : BaseCommands, IGetOneCommentCommand
    {
        private readonly IMapper _mapper;

        public EfGetOneCommentCommand(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public CommentDto Execute(int request)
        {
            Comment comment = context.Comments.Find(request);

            if (comment == null) {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<Comment, CommentDto>(comment);
        }
    }
}
