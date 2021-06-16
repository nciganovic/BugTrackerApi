using Application.Dto;
using Application.Queries.ApplicationUserQueries;
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
using Application.Extensions;

namespace Implementation.Queries.ApplicationUserQueries
{
    public class EfGetApplicationUsersQuery : BaseUseCase, IGetApplicationUsersQuery
    {
        private IMapper _mapper;

        public EfGetApplicationUsersQuery(BugTrackerContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public int Id => 12;

        public string Name => "Get applicationUsers";

        public IEnumerable<GetApplicationUserDto> Execute(ApplicationUserSearch request)
        {
            var query = context.ApplicaitonUsers.AsQueryable();

            if (request.FirstNameKeyword != null)
            {
                query = query
                    .Where(x => 
                    x.FirstName.ToLower().Contains(request.FirstNameKeyword.ToLower()));
            }

            if (request.LastNameKeyword != null)
            {
                query = query
                        .Where(x =>
                        x.LastName.ToLower().Contains(request.LastNameKeyword.ToLower()));
            }

            if (request.EmailKeyword != null)
            {
                query = query
                        .Where(x =>
                        x.Email.ToLower().Contains(request.EmailKeyword.ToLower()));
            }

            if (request.RoleId != null)
            {
                query = query.Where(x => x.RoleId == request.RoleId);
            }

            if (request.OnlyActive.HasValue)
            {
                if (request.OnlyActive == true)
                {
                    query = query.Where(x => x.DeletedAt == null);
                }
            }

            query = query.SkipItems(request.Page, request.ItemsPerPage);

            return query.Select(x => _mapper.Map<ApplicationUser, GetApplicationUserDto>(x)).ToList();
        }
    }
}
