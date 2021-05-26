using Application.Commands.ApplicationUserCommands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Hash;

namespace Implementation.EfCommands.EfApplicationUserCommands
{
    public class EfAddApplicationUserCommand : BaseCommands, IAddApplicationUserCommand
    {
        public EfAddApplicationUserCommand(BugTrackerContext context) : base(context)
        {

        }

        public int Id => 6;

        public string Name => "Add applicationUser";

        public void Execute(ApplicationUser request)
        {
            request.CreatedAt = DateTime.Now;

            HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);

            request.Password = hashSalt.Hash;
            request.Salt = hashSalt.Salt;

            context.Add(request);
            context.SaveChanges();
        }

        private bool IsEmailAlreadyTaken(string email) {
            if (context.ApplicaitonUsers.Any(x => x.Email == email))
            {
                return true;
            }

            return false;
        }
    }
}
