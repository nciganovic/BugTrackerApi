﻿using Application.Dto;
using Application.Queries.AttachmentQueries;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.AttachmentQueries
{
    public class EfGetOneAttachmentQuery : BaseUseCase, IGetOneAttachmentQuery
    {
        private readonly IMapper _mapper;

        public EfGetOneAttachmentQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 46;

        public string Name => "Get one attachment query";

        public GetAttachmentDto Execute(int search)
        {
            Attachment item = context.Attachments.Find(search);

            if (item.DeletedAt != null)
            {
                return null;
            }

            return _mapper.Map<GetAttachmentDto>(item);
        }
    }
}
