using Application.Commands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands
{
    public class CompanyCommands : BaseCommands, ICompanyCommands
    {
        public CompanyCommands(BugTrackerContext context) : base(context)
        {

        }

        public void Create(Company company)
        {
            if (IsNameAlreadyTaken(company.Name))
            {
                throw new EntityAlreadyExists();
            }

            context.Add(company);
            context.SaveChanges();
        }

        public Company Delete(int id)
        {
            Company item = context.Companies.Find(id);

            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.Companies.Update(item);
            context.SaveChanges();
            return item;
        }

        public IEnumerable<Company> Read()
        {
            return context.Companies.Select(x => new Company
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList();
        }

        public Company Read(int id)
        {
            return context.Companies.Where(x => x.Id == id).Select(x => new Company
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList().FirstOrDefault();
        }

        public void Update(Company company)
        {
            Company item = context.Companies.Find(company.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (IsNameAlreadyTaken(company.Name))
                throw new EntityAlreadyExists();

            company.CreatedAt = item.CreatedAt;
            company.UpdatedAt = DateTime.Now;
            company.DeletedAt = item.DeletedAt;

            var tp = context.Companies.Attach(company);
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
