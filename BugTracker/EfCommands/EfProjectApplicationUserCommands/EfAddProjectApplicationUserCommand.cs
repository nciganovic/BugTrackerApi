using Application.Commands.ApplicationUserCommands;
using Application.Commands.ProjectApplicationUserCommands;
using Application.Commands.ProjectCommands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfProjectApplicationUserCommands
{
    public class EfAddProjectApplicationUserCommand : BaseCommands, IAddProjectApplicationUserCommand
    {
        private readonly IGetOneProjectCommand _getOneProjectCommand;
        private readonly IGetOneApplicationUserCommand _getOneApplicationUserCommand;

        public EfAddProjectApplicationUserCommand(BugTrackerContext context ,
            IGetOneProjectCommand getOneProjectCommand ,
            IGetOneApplicationUserCommand getOneApplicationUserCommand) : base(context)
        {
            _getOneProjectCommand = getOneProjectCommand;
            _getOneApplicationUserCommand = getOneApplicationUserCommand;
        }

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
