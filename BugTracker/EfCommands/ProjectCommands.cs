using Application.Commands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Exceptions;

namespace EfCommands
{
    public class ProjectCommands : BaseCommands, IProjectCommands
    {
        public ProjectCommands(BugTrackerContext context) : base(context)
        {

        }

        public void Create(Project project)
        {
            if (!CompanyExists(project.CompanyId))
                throw new EntityNotFoundException();

            if (IsNameAlreadyTaken(project.CompanyId, project.Name))
                throw new Exception($"Company with id {project.CompanyId} already has project with name {project.Name}");

            context.Add(project);
            context.SaveChanges();
        }

        public Project Delete(int id)
        {
            Project item = context.Projects.Find(id);

            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.Projects.Update(item);
            context.SaveChanges();
            return item;
        }

        public IEnumerable<Project> Read()
        {
            return context.Projects.Select(x => new Project
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Company = x.Company,
                CompanyId = x.CompanyId,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList();
        }

        public Project Read(int id)
        {
            return context.Projects.Where(x => x.Id == id).Select(x => new Project
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Company = x.Company,
                CompanyId = x.CompanyId,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList().FirstOrDefault();
        }

        public void Update(Project project)
        {
            Project item = context.Projects.Find(project.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (!CompanyExists(project.CompanyId))
                throw new EntityNotFoundException();

            if (IsNameAlreadyTaken(project.CompanyId, project.Name))
                throw new Exception($"Company with id {project.CompanyId} already has project with name {project.Name}");


            project.CreatedAt = item.CreatedAt;
            project.UpdatedAt = DateTime.Now;
            project.DeletedAt = item.DeletedAt;

            var tp = context.Projects.Attach(project);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        private bool IsNameAlreadyTaken(int companyId, string name)
        {
            if (context.Projects.Any(x => x.Name == name && x.CompanyId == companyId))
            {
                return true;
            }

            return false;
        }

        private bool CompanyExists(int companyId) 
        { 
            if(context.Companies.Any(x => x.Id == companyId))
            {
                return true;
            }

            return false;
        }
    }
}
