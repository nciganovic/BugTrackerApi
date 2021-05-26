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
    public class EfAddCompanyApplicationUserRoleCommand : BaseCommands, IAddCompanyApplicationUserRoleCommand
    {
        private readonly IGetOneCompanyQuery _getOneCompanyCommand;
        private readonly IGetOneApplicationUserQuery _getOneApplicationUserCommand;
        private readonly IGetOneRoleQuery _getOneRoleQuery;

        public EfAddCompanyApplicationUserRoleCommand(BugTrackerContext context,
            IGetOneCompanyQuery getOneCompanyCommand,
            IGetOneApplicationUserQuery getOneApplicationUserCommand,
            IGetOneRoleQuery getOneRoleQuery) : base(context)
        {
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
            _getOneCompanyCommand = getOneCompanyCommand;
            _getOneRoleQuery = getOneRoleQuery;
        }

        public int Id => 12;

        public string Name => "Add company applicationUser";

        public void Execute(CompanyApplicationUserRole request)
        {
            var query = context.CompanyApplicationUserRoles.AsQueryable();

            if (query.Where(x => x.CompanyId == request.CompanyId && x.ApplicationUserId == x.ApplicationUserId).FirstOrDefault() != null) {
                throw new EntityAlreadyExists();
            }

            if (request.CompanyId != 0)
            {
                _getOneCompanyCommand.Execute(request.CompanyId);
            }
            else {
                throw new Exception("CompanyId is required field and cannot be 0");
            }

            if (request.ApplicationUserId != 0) {
                _getOneApplicationUserCommand.Execute(request.ApplicationUserId);
            }
            else
            {
                throw new Exception("ApplicationUserId is required field and cannot be 0");
            }

            if (request.RoleId != 0)
            {
                _getOneRoleQuery.Execute(request.RoleId);
            }
            else
            {
                throw new Exception("RolerId is required field and cannot be 0");
            }

            request.CreatedAt = DateTime.Now;
            context.CompanyApplicationUserRoles.Add(request);
            context.SaveChanges();
        }
    }
}
