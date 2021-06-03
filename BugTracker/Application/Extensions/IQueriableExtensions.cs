using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class IQueriableExtensions
    {
        public static IQueryable<T> SkipItems<T>(this IQueryable<T> query, int? page, int? itemsPerPage) 
        {
            if (page != null && itemsPerPage != null)
            {
                if (page > 0 && itemsPerPage > 0)
                {
                   query = query
                         .Skip(ItemsToSkip((int)page, (int)itemsPerPage))
                         .Take((int)itemsPerPage);
                }
            }

            return query;
        }

        private static int ItemsToSkip(int page, int itemsPerPage)
        {
            int skipCount = (page - 1) * itemsPerPage;
            return skipCount;
        }
    }
}
