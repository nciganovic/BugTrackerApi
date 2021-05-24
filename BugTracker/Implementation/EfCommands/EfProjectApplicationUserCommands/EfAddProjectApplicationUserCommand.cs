using Application.Commands.ApplicationUserCommands;
using Application.Commands.ProjectApplicationUserCommands;
using Application.Commands.ProjectCommands;
using Application.Queries.ApplicationUserQueries;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfProjectApplicationUserCommands
{
    public class EfAddProjectApplicationUserCommand : BaseCommands, IAddProjectApplicationUserCommand
    {
        private readonly IGetOneProjectCommand _getOneProjectCommand;
        private readonly IGetOneApplicationUserQuery _getOneApplicationUserCommand;

        public EfAddProjectApplicationUserCommand(BugTrackerContext context ,
            IGetOneProjectCommand getOneProjectCommand ,
            IGetOneApplicationUserQuery getOneApplicationUserCommand) : base(context)
        {
            _getOneProjectCommand = getOneProjectCommand;
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
        }

        public int Id => 20;

        public string Name => "Add project applicationUser";

        public void Execute(ProjectApplicationUser request)
        {
            if (request.ProjectId != 0)
            {
                _getOneProjectCommand.Execute(request.ProjectId);
            }
            else
            {
                throw new Exception("ProjectId is required field and cannot be 0");
            }

            if (request.ApplicationUserId != 0)
            {
                _getOneApplicationUserCommand.Execute(request.ApplicationUserId);
            }
            else
            {
                throw new Exception("ApplicationUserId is required field and cannot be 0");
            }

            request.CreatedAt = DateTime.Now;
            context.ProjectApplicationUsers.Add(request);
            context.SaveChanges();
        }
    }
}
