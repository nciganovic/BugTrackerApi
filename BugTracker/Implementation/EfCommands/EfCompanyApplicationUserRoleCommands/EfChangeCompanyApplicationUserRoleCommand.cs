using Application.Commands.ApplicationUserCommands;
using Application.Commands.CompanyApplicationUserRoleCommands;
using Application.Commands.CompanyCommands;
using Application.Commands.Roles;
using Application.Dto;
using Application.Exceptions;
using Application.Queries.ApplicationUserQueries;
using Application.Queries.CompanyQueries;
using Application.Queries.RoleQueries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfCompanyApplicationUserRoleCommands
{
    public class EfChangeCompanyApplicationUserRoleCommand : BaseCommands, IChangeCompanyApplicationUserRoleCommand
    {
        public EfChangeCompanyApplicationUserRoleCommand(BugTrackerContext context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Change company applicationUser";

        public void Execute(ChangeCompanyApplicationUserRoleDto request)
        {
            CompanyApplicationUserRole item = context.CompanyApplicationUserRoles
                .Where(x => x.ApplicationUserId == request.ApplicationUserId
                && x.CompanyId == request.CompanyId)
                    .FirstOrDefault();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            item.CompanyId = request.CompanyId;
            item.ApplicationUserId = request.ApplicationUserId;
            item.RoleId = request.RoleId;

            item.UpdatedAt = DateTime.Now;
          
            var tp = context.CompanyApplicationUserRoles.Attach(item);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
