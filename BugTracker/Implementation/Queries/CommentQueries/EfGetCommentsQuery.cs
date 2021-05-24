﻿using Application.Queries.CommentQueries;
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
using Implementation.EfCommands;

namespace Implementation.Queries.CommentQueries
{
    public class EfGetCommentsQuery : BaseCommands, IGetCommentsQuery
    {
        private readonly IMapper _mapper;

        public EfGetCommentsQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Get comments";

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
