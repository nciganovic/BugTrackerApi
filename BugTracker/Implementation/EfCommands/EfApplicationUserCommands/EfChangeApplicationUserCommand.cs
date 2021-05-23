using Application.Commands.ApplicationUserCommands;
using Application.Exceptions;
using Application.Hash;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfApplicationUserCommands
{
    public class EfChangeApplicationUserCommand : BaseCommands, IChangeApplicationUserCommand
    {
        public EfChangeApplicationUserCommand(BugTrackerContext bugTrackerContext) : base(bugTrackerContext)
        {

        }

        public void Execute(ApplicationUser request)
        {
            ApplicationUser item = context.ApplicaitonUsers.Find(request.Id);

            if (item == null)
                throw new EntityNotFoundException();

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (IsEmailAlreadyTaken(request.Email))
                throw new EntityAlreadyExists();

            HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);

            request.Password = hashSalt.Hash;
            request.Salt = hashSalt.Salt;

            request.CreatedAt = item.CreatedAt;
            request.UpdatedAt = DateTime.Now;
            request.DeletedAt = item.DeletedAt;

            var tp = context.ApplicaitonUsers.Attach(request);
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
    }
}
