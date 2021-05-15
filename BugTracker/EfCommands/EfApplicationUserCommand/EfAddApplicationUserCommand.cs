﻿using Application.Commands.ApplicationUserCommands;
using Application.Exceptions;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Hash;

namespace EfCommands.EfApplicationUserCommand
{
    public class EfAddApplicationUserCommand : BaseCommands, IAddApplicationUserCommand
    {
        public EfAddApplicationUserCommand(BugTrackerContext context) : base(context)
        {

        }

        public void Execute(ApplicationUser request)
        {
            if (IsEmailAlreadyTaken(request.Email))
            {
                throw new EntityAlreadyExists();
            }

            HashSalt hashSalt = Encryption.GenerateSaltedHash(64, request.Password);

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
