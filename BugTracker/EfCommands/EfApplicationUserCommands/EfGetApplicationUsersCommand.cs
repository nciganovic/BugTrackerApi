using Application.Commands.ApplicationUserCommands;
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

namespace EfCommands.EfApplicationUserCommands
{
    public class EfGetApplicationUsersCommand : BaseCommands, IGetApplicationUsersCommand
    {
        private IMapper _mapper;

        public EfGetApplicationUsersCommand(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public IEnumerable<ApplicationUserDto> Execute(ApplicationUserSearch request)
        {
            var query = context.ApplicaitonUsers.AsQueryable();

            if (request.Keyword != null)
            {
                query = query
                    .Where(x => 
                    x.FirstName.ToLower().Contains(request.Keyword.ToLower()) ||
                 x.LastName.ToLower().Contains(request.Keyword.ToLower()) ||
                 x.Email.ToLower().Contains(request.Keyword.ToLower()));
            }

            if (request.OnlyActive.HasValue)
            {
                if (request.OnlyActive == true)
                {
                    query = query.Where(x => x.DeletedAt == null);
                }
            }

            return query.Select(x => _mapper.Map<ApplicationUser, ApplicationUserDto>(x)).ToList();
        }
    }
}
