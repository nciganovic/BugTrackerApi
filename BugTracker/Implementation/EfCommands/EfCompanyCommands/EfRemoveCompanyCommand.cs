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
    public class EfRemoveCompanyCommand : BaseCommands, IRemoveCompanyCommand
    {
        public EfRemoveCompanyCommand(BugTrackerContext context) : base(context)
        {

        }

        public void Execute(int request)
        {
            Domain.Company item = context.Companies.Find(request);

            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.Companies.Update(item);
            context.SaveChanges();
        }
    }
}
