using Application.Dto;
using Application.Queries.ApplicationUserQueries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfApplicationUserCommands
{
    public class EfGetApplicationUsersCommand : BaseCommands, IGetApplicationUsersQuery
    {
        private IMapper _mapper;

        public EfGetApplicationUsersCommand(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 9;

        public string Name => "Get applicationUsers";

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
