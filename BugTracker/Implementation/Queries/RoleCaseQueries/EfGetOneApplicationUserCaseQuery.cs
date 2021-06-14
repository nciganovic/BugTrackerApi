using Application.Dto;
using Application.Queries.RoleCaseQueries;
using DataAccess;
using Domain;
using Implementation.EfCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.RoleCaseQueries
{
    public class EfGetOneApplicationUserCaseQuery : BaseUseCase, IGetOneRoleCaseQuery
    {
        public EfGetOneApplicationUserCaseQuery(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 40;

        public string Name => "Get one applicationUser case query";

        public RoleUserCase Execute(RemoveRoleCaseDto search)
        {
            var item = context.RoleCases
                .FirstOrDefault(x => x.RoleId == search.RoleId
                && x.UseCaseId == search.UseCaseId);

            return item;
        }
    }
}
