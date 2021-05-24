using Application.Commands.ProjectCommands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfProjectCommands
{
    public class EfChangeProjectCommand : BaseCommands, IChangeProjectCommand
    {
        public int Id => 24;

        public string Name => "Change project";

        public EfChangeProjectCommand(BugTrackerContext context) : base(context)
        {

        }

        public void Execute(Project request)
        {
            Project item = context.Projects.Find(request.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (!CompanyExists(request.CompanyId))
                throw new EntityNotFoundException();

            if (IsNameAlreadyTaken(request.CompanyId, request.Name))
                throw new Exception($"Company with id {request.CompanyId} already has project with name {request.Name}");


            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.Projects.Attach(request);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
