using Application.Commands.AccountCommands;
using Application.Hash;
using Application.Interfaces;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfAccountCommands
{
    public class EfChangeProfileCommand : IChangeProfileCommand
    {
        private readonly BugTrackerContext _context;
        private readonly IApplicationActor _actor;

        public EfChangeProfileCommand(BugTrackerContext context, IApplicationActor actor)
        {
            _actor = actor;
            _context = context;
        }

        public int Id => 52;

        public string Name => "Change profile command";

        public void Execute(ApplicationUser request)
        {
            var item = _context.ApplicaitonUsers.Find(_actor.Id);

            if (request.FirstName != null)
            {
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

            if (request.Password != null)
            {
                HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);

                item.Password = hashSalt.Hash;
                item.Salt = hashSalt.Salt;
            }

            item.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
