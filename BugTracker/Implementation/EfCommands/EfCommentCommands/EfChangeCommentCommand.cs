using Application.Commands.ApplicationUserCommands;
using Application.Commands.CommentCommands;
using Application.Commands.TicketCommands;
using Application.Dto;
using Application.Exceptions;
using Application.Queries.ApplicationUserQueries;
using Application.Queries.TicketQueries;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfCommentCommands
{
    public class EfChangeCommentCommand : BaseUseCase, IChangeCommentCommand
    {
        private readonly IMapper _mapper;

        public EfChangeCommentCommand(BugTrackerContext context
            , IMapper mapper
            ) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 2;

        public string Name => "Change comment";

        public void Execute(ChangeCommentDto request)
        {
            Comment item = context.Comments.Find(request.Id);

            if (request.Text != null) {
                item.Text = request.Text;
            }

            if (request.ApplicationUserId != null) {
                item.ApplicationUserId = (int)request.ApplicationUserId;
            }

            if (request.TicketId != null)
            {
                item.TicketId = (int)request.TicketId;
            }

            item.UpdatedAt = DateTime.Now;

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            var tp = context.Comments.Attach(item);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
