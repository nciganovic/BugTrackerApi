using Application.Commands.ApplicationUserCommands;
using Application.Commands.CompanyApplicationUserCommands;
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

namespace Implementation.EfCommands.EfCompanyApplicationUserCommands
{
    public class EfChangeCompanyApplicationUserCommand : BaseCommands, IChangeCompanyApplicationUserCommand
    {
        private readonly IGetOneCompanyQuery _getOneCompanyCommand;
        private readonly IGetOneApplicationUserQuery _getOneApplicationUserCommand;
        private readonly IGetOneRoleQuery _getOneRoleQuery;

        public EfChangeCompanyApplicationUserCommand(BugTrackerContext context, 
            IGetOneCompanyQuery getOneCompanyCommand,
            IGetOneApplicationUserQuery getOneApplicationUserCommand,
            IGetOneRoleQuery getOneRoleQuery) : base(context)
        {
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
            _getOneCompanyCommand = getOneCompanyCommand;
            _getOneRoleQuery = getOneRoleQuery;
        }

        public int Id => 13;

        public string Name => "Chaneg company applicationUser";

        public void Execute(CompanyApplicationUser request)
        {
            CompanyApplicationUser item = context.CompanyApplicationUsers
                .Where(x => x.ApplicationUserId == request.ApplicationUserId
                && x.CompanyId == request.CompanyId)
                    .FirstOrDefault();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (item == null)
            {
                throw new EntityNotFoundException();
            }

            if (request.CompanyId != 0)
            {
                _getOneCompanyCommand.Execute(request.CompanyId);
            }
            else
            {
                throw new Exception("CompanyId is required field and cannot be 0");
            }

            if (request.ApplicationUserId != 0)
            {
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

            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.CompanyApplicationUsers.Attach(request);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
