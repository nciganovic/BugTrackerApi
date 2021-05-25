using Application.Commands.ApplicationUserCommands;
using Application.Dto;
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

        public int Id => 7;

        public string Name => "Change applicationUser";

        public void Execute(ChangeApplicationUserDto request)
        {
            ApplicationUser item = context.ApplicaitonUsers.Find(request.Id);

            if (request.FirstName != null) {
                item.FirstName = request.FirstName;
            }

            if (request.LastName != null)
            {
                item.LastName = request.LastName;
            }

            if (request.Email != null)
            {
                item.Email = request.Email;
            }

            context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

            if (request.Password != null) { 
                HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);

                item.Password = hashSalt.Hash;
                item.Salt = hashSalt.Salt;
            }

            item.UpdatedAt = DateTime.Now;

            var tp = context.ApplicaitonUsers.Attach(item);
            tp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
