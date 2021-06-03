using Application.Commands.ApplicationUserCommands;
using Application.Commands.CompanyApplicationUserRoleCommands;
using Application.Commands.CompanyCommands;
using Application.Commands.Roles;
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
    public class EfAddCompanyApplicationUserRoleCommand : BaseUseCase, IAddCompanyApplicationUserRoleCommand
    {
        public EfAddCompanyApplicationUserRoleCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 12;

        public string Name => "Add company applicationUser";

        public void Execute(CompanyApplicationUserRole request)
        {
            request.CreatedAt = DateTime.Now;
            context.CompanyApplicationUserRoles.Add(request);
            context.SaveChanges();
        }
    }
}
