﻿using Application.Dto;
using Application.Exceptions;
using Application.Queries.CompanyApplicationUserQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.CompanyApplicationUserQueries
{
    public class EfGetOneCompanyApplicationUserQuery : BaseCommands, IGetOneCompanyApplicationUserQuery
    {
        private readonly IMapper _mapper;

        public EfGetOneCompanyApplicationUserQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 14;

        public string Name => "Get one company applicationUser";

        public CompanyApplicationUserDto Execute(CompanyApplicationUserSearch request)
        {
            CompanyApplicationUserRole item = context.CompanyApplicationUserRoles
                .Where(x => x.ApplicationUserId == request.ApplicationUserId 
                && x.CompanyId == request.CompanyId)
                    .FirstOrDefault();

            if (item == null) {
                throw new EntityNotFoundException();
            }

            return _mapper.Map<CompanyApplicationUserRole, CompanyApplicationUserDto>(item);
        }
    }
}
