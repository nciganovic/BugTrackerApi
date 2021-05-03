using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface IRoleCommands
    {
        public void Create(Role role);
        public IEnumerable<Role> Read();
        public Role Read(int id);
        public void Update(Role role);
        public Role Delete(int id);
    }
}
