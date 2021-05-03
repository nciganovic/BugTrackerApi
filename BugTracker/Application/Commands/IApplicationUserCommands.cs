using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface IApplicationUserCommands
    {
        public void Create(ApplicationUser applicationUser);
        public IEnumerable<ApplicationUser> Read();
        public ApplicationUser Read(int id);
        public void Update(ApplicationUser applicationUser);
        public ApplicationUser Delete(int id);
    }
}
