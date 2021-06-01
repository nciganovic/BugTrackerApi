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
    public class EfAddCompanyCommand : BaseCommands, IAddCompanyCommand
    {
        public EfAddCompanyCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 15;

        public string Name => "Add company";

        public void Execute(Domain.Company request)
        {
            context.Add(request);
            context.SaveChanges();
        }
    }
}
