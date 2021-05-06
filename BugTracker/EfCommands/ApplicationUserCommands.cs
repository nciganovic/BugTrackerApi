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
    public class ApplicationUserCommands : BaseCommands, IApplicationUserCommands
    {
        public ApplicationUserCommands(BugTrackerContext context) : base(context)
        {

        }

        public void Create(ApplicationUser applicationUser)
        {
            if (IsEmailAlreadyTaken(applicationUser.Email))
            {
                throw new EntityAlreadyExists();
            }

            if (!RoleExists(applicationUser.RoleId)){
                throw new EntityNotFoundException();
            }

            context.Add(applicationUser);
            context.SaveChanges();
        }

        public ApplicationUser Delete(int id)
        {
            ApplicationUser item = context.ApplicaitonUsers.Find(id);

            if (item == null)
                throw new EntityNotFoundException();

            item.DeletedAt = DateTime.Now;

            context.ApplicaitonUsers.Update(item);
            context.SaveChanges();
            return item;
        }

        public IEnumerable<ApplicationUser> Read()
        {
            return context.ApplicaitonUsers.Select(x => new ApplicationUser
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                RoleId = x.RoleId,
                Role = x.Role,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt,
                Comments = x.Comments,
                CompanyApplicaitonUsers = x.CompanyApplicaitonUsers,
                ProjectApplicaitonUsers = x.ProjectApplicaitonUsers,
                DeveloperTickets = x.DeveloperTickets,
                IssuerTickets = x.IssuerTickets
            }).ToList();
        }

        public ApplicationUser Read(int id)
        {
            return context.ApplicaitonUsers.Where(x => x.Id == id).Select(x => new ApplicationUser
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                RoleId = x.RoleId,
                Role = x.Role,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                DeletedAt = x.DeletedAt,
                Comments = x.Comments,
                CompanyApplicaitonUsers = x.CompanyApplicaitonUsers,
                ProjectApplicaitonUsers = x.ProjectApplicaitonUsers,
                DeveloperTickets = x.DeveloperTickets,
                IssuerTickets = x.IssuerTickets
            }).ToList().FirstOrDefault();
        }

        public void Update(ApplicationUser applicationUser)
        {
            ApplicationUser item = context.ApplicaitonUsers.Find(applicationUser.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (IsEmailAlreadyTaken(applicationUser.Email))
                throw new EntityAlreadyExists();

            if (!RoleExists(applicationUser.RoleId))
            {
                throw new EntityNotFoundException();
            }

            applicationUser.CreatedAt = item.CreatedAt;
            applicationUser.UpdatedAt = DateTime.Now;
            applicationUser.DeletedAt = item.DeletedAt;

            var tp = context.ApplicaitonUsers.Attach(applicationUser);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        private bool IsEmailAlreadyTaken(string email)
        {
            if (context.ApplicaitonUsers.Any(x => x.Email == email))
            {
                return true;
            }

            return false;
        }

        private bool RoleExists(int roleId) {
            if (context.Roles.Any(x => x.Id == roleId)) {
                return true;   
            }

            return false;
        }
    }
}
