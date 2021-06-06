using Application.Dto;
using Application.Queries.ApplicationUserCaseQueries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ApplicationUserCaseQueries
{
    public class EfGetOneApplicationUserCaseQuery : IGetOneApplicationUserCaseQuery
    {
        private readonly BugTrackerContext _context;

        public EfGetOneApplicationUserCaseQuery(BugTrackerContext context)
        {
            _context = context;
        }

        public int Id => 40;

        public string Name => "Get one applicationUser case query";

        public ApplicationUserCase Execute(RemoveApplicationUserCaseDto search)
        {
            var item = _context.ApplicationUserCases
                .FirstOrDefault(x => x.ApplicationUserId == search.ApplicationUserId
                && x.UseCaseId == search.UseCaseId);

            return item;
        }
    }
}
