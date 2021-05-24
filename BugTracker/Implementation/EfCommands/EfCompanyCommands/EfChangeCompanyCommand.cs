using Application.Commands.CompanyCommands;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfCompanyCommands
{
    public class EfChangeCompanyCommand : BaseCommands, IChangeCompanyCommand
    {
        public EfChangeCompanyCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 16;

        public string Name => "Change company";

        public void Execute(Domain.Company request)
        {
            Domain.Company item = context.Companies.Find(request.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (IsNameAlreadyTaken(request.Name))
                throw new EntityAlreadyExists();

            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.Companies.Attach(request);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
        private bool IsNameAlreadyTaken(string name)
        {
            if (context.Companies.Any(x => x.Name == name))
            {
                return true;
            }

            return false;
        }

    }
}
