using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface IProjectCommands
    {
        public void Create(Project project);
        public IEnumerable<Project> Read();
        public Project Read(int id);
        public void Update(Project project);
        public Project Delete(int id);
    }
}
