using Application.Commands.CompanyCommands;
using Application.Exceptions;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.EfCompanyCommands
{
    public class EfAddCompanyCommand : BaseCommands, IAddCompanyCommand
    {
        public EfAddCompanyCommand(BugTrackerContext context) : base(context)
        {

        }

        public void Execute(Domain.Company request)
        {
            if (IsNameAlreadyTaken(request.Name))
            {
                throw new EntityAlreadyExists();
            }

            context.Add(request);
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
