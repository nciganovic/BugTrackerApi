using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public interface ICompanyCommands
    {
        public void Create(Company company);
        public IEnumerable<Company> Read();
        public Company Read(int id);
        public void Update(Company company);
        public Company Delete(int id);
    }
}
