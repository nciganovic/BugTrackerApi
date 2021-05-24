using Application.Commands.ApplicationUserCommands;
using Application.Commands.CompanyApplicationUserCommands;
using Application.Commands.CompanyCommands;
using Application.Commands.Roles;
using Application.Exceptions;
using Application.Queries.ApplicationUserQueries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfCompanyApplicationUserCommands
{
    public class EfAddCompanyApplicationUserCommand : BaseCommands, IAddCompanyApplicationUserCommand
    {
        private readonly IGetOneCompanyCommand _getOneCompanyCommand;
        private readonly IGetOneApplicationUserQuery _getOneApplicationUserCommand;
        private readonly IGetOneRoleCommand _getOneRoleCommand;

        public EfAddCompanyApplicationUserCommand(BugTrackerContext context,
            IGetOneCompanyCommand getOneCompanyCommand,
            IGetOneApplicationUserQuery getOneApplicationUserCommand,
            IGetOneRoleCommand getOneRoleCommand) : base(context)
        {
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
            _getOneCompanyCommand = getOneCompanyCommand;
            _getOneRoleCommand = getOneRoleCommand;
        }

        public int Id => 12;

        public string Name => "Add company applicationUser";

        public void Execute(CompanyApplicationUser request)
        {
            var query = context.CompanyApplicationUsers.AsQueryable();

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
                _getOneRoleCommand.Execute(request.RoleId);
            }
            else
            {
                throw new Exception("RolerId is required field and cannot be 0");
            }

            request.CreatedAt = DateTime.Now;
            context.CompanyApplicationUsers.Add(request);
            context.SaveChanges();
        }
    }
}
