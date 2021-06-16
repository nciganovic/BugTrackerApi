using Application.Queries.UseCaseQueries;
using Application.Searches;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.UseCaseLogQueries
{
    public class EfGetUseCaseLogsQuery : BaseUseCase, IGetUseCaseLogsQuery
    {

        public EfGetUseCaseLogsQuery(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 91;

        public string Name => "Get use case logs query";

        public IEnumerable<UseCaseLog> Execute(UseCaseLogSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();

            if (search.StartDate != null) 
            {
                query = query.Where(x => x.Date > search.StartDate);    
            }

            if (search.EndDate != null)
            {
                query = query.Where(x => x.Date < search.EndDate);
            }

            if (search.UseCaseNameKeyword != null)
            {
                query = query.Where(x => x.UseCaseName.ToLower().Contains(search.UseCaseNameKeyword.ToLower()));
            }

            if (search.DataKeyword != null)
            {
                query = query.Where(x => x.Data.ToLower().Contains(search.DataKeyword.ToLower()));
            }

            if (search.ActorKeyword != null)
            {
                query = query.Where(x => x.Actor.ToLower().Contains(search.ActorKeyword.ToLower()));
            }

            return query.ToList();
        }
    }
}
