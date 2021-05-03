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
    public class RoleCommands : BaseCommands, IRoleCommands
    {
        public RoleCommands(BugTrackerContext bugTrackerContext) : base(bugTrackerContext)
        {

        }

        public void Create(Role role)
        {
            if (IsNameAlreadyTaken(role.Name))
            {
                throw new EntityAlreadyExists();
            }

            context.Add(role);
            context.SaveChanges();
        }

        public Role Delete(int id)
        {
            Role item = context.Roles.Find(id);

            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.Roles.Update(item);
            context.SaveChanges();
            return item;
        }

        public IEnumerable<Role> Read()
        {
            return context.Roles.Select(x => new Role
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList();
        }

        public Role Read(int id)
        {
            return context.Roles.Where(x => x.Id == id).Select(x => new Role
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt
            }).ToList().FirstOrDefault();
        }

        public void Update(Role role)
        {
            Role item = context.Roles.Find(role.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (IsNameAlreadyTaken(role.Name))
                throw new EntityAlreadyExists();

            role.CreatedAt = item.CreatedAt;
            role.UpdatedAt = DateTime.Now;
            role.DeletedAt = item.DeletedAt;

            var tp = context.Roles.Attach(role);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        private bool IsNameAlreadyTaken(string name)
        {
            if (context.Roles.Any(x => x.Name == name))
            {
                return true;
            }

            return false;
        }
    }
}
