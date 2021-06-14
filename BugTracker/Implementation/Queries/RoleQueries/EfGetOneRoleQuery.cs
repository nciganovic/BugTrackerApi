﻿using Application.Dto;
using Application.Exceptions;
using Application.Interfaces;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Commands.Roles;
using Application.Queries.RoleQueries;
using Implementation.EfCommands;
using AutoMapper;
using Domain;

namespace Implementation.Queries.RoleQueries
{
    public class EfGetOneRoleQuery : BaseUseCase, IGetOneRoleQuery
    {
        private IMapper _mapper;

        public EfGetOneRoleQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 30;

        public string Name => "Get one role";

        public GetRoleDto Execute(int request)
        {
            var role = context.Roles.Find(request);

            if (role.DeletedAt != null)
            {
                return null;
            }

            return _mapper.Map<Role, GetRoleDto>(role);
        }
    }
}
