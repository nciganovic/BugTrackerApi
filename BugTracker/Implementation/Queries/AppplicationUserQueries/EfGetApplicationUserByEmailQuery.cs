﻿using Application.Dto;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Queries.ApplicationUserQueries;
using Implementation.EfCommands;

namespace Implementation.Queries.ApplicationUserQueries
{
    public class EfGetApplicationUserByEmailQuery : BaseUseCase, IGetApplicationUserByEmailQuery
    {
        private readonly IMapper _mapper;

        public EfGetApplicationUserByEmailQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 8;

        public string Name => "Get applicationUser by email";

        public GetApplicationUserDto Execute(string request)
        {
            ApplicationUser user = context.ApplicaitonUsers.Where(x => x.Email == request).FirstOrDefault();

            if (user == null) {
                throw new EntityNotFoundException();
            }

            GetApplicationUserDto applicationUserDto = _mapper.Map<GetApplicationUserDto>(user);
            return applicationUserDto;
        }
    }
}
