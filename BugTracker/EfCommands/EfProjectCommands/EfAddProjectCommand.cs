using Application.Commands.ProjectCommands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfProjectCommands
{
    public class EfAddProjectCommand : BaseCommands, IAddProjectCommand
    {
        public EfAddProjectCommand(BugTrackerContext context) : base(context)
        {

        }

        public void Execute(Project request)
        {
            if (!CompanyExists(request.CompanyId))
                throw new EntityNotFoundException();

            if (IsNameAlreadyTaken(request.CompanyId, request.Name))
                throw new Exception($"Company with id {request.CompanyId} already has project with name {request.Name}");

            context.Add(request);
            context.SaveChanges();
        }

        private bool IsNameAlreadyTaken(int companyId, string name)
        {
            if (context.Projects.Any(x => x.Name == name && x.CompanyId == companyId))
            {
                return true;
            }

            return false;
        }

        private bool CompanyExists(int companyId)
        {
            if (context.Companies.Any(x => x.Id == companyId))
            {
                return true;
            }

            return false;
        }
    }
}
