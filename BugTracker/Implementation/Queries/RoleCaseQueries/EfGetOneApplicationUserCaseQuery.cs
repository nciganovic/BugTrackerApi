using Application.Dto;
using Application.Queries.RoleCaseQueries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.RoleCaseQueries
{
    public class EfGetOneApplicationUserCaseQuery : IGetOneRoleCaseQuery
    {
        private readonly BugTrackerContext _context;

        public EfGetOneApplicationUserCaseQuery(BugTrackerContext context)
        {
            _context = context;
        }

        public int Id => 40;

        public string Name => "Get one applicationUser case query";

        public RoleUserCase Execute(RemoveRoleCaseDto search)
        {
            var item = _context.RoleCases
                .FirstOrDefault(x => x.RoleId == search.RoleId
                && x.UseCaseId == search.UseCaseId);

            return item;
        }
    }
}
