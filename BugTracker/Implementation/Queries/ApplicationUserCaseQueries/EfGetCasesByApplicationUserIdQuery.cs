using Application.Queries.ApplicationUserCaseQueries;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ApplicationUserCaseQueries
{
    public class EfGetCasesByApplicationUserIdQuery : IGetCasesByApplicationUserIdQuery
    {
        private readonly BugTrackerContext _bugTrackerContext;

        public EfGetCasesByApplicationUserIdQuery(BugTrackerContext bugTrackerContext)
        {
            _bugTrackerContext = bugTrackerContext;
        }

        public int Id => 37;

        public string Name => "Get cases by applicationUser id query";

        public IEnumerable<int> Execute(int search)
        {
            var query = _bugTrackerContext.ApplicationUserCases.AsQueryable();

            query = query.Where(x => x.ApplicationUserId == search);

            return query.Select(x => x.UseCaseId).ToList();
        }
    }
}
