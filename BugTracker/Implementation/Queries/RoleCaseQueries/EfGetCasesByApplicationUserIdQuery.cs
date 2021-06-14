using Application.Queries.RoleCaseQueries;
using DataAccess;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.RoleCaseQueries
{
    public class EfGetCasesByApplicationUserIdQuery : BaseUseCase,  IGetCasesByRoleIdQuery
    {

        public EfGetCasesByApplicationUserIdQuery(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 37;

        public string Name => "Get cases by applicationUser id query";

        public IEnumerable<int> Execute(int search)
        {
            var query = context.RoleCases.AsQueryable();

            query = query.Where(x => x.RoleId == search);

            return query.Select(x => x.UseCaseId).ToList();
        }
    }
}
