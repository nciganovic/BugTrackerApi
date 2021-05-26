using Application.Interfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.CompanyApplicationUserRoleCommands
{
    public interface IChangeCompanyApplicationUserRoleCommand : ICommand<CompanyApplicationUserRole>
    {
    }
}
