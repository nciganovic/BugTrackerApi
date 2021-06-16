﻿using Application.Commands.AccountCommands;
using Application.Dto;
using Application.Email;
using Application.Hash;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.EfCommands.EfAccountCommands
{
    public class EfRegisterCommand : BaseUseCase, IRegisterCommand
    {
        private readonly IEmailSender _emailSender;

        public EfRegisterCommand(BugTrackerContext context, IEmailSender emailSender) : base(context)
        { 
            _emailSender = emailSender;
        }

        public int Id => 3;

        public string Name => "Register user command";

        public void Execute(ApplicationUser request)
        {
            request.CreatedAt = DateTime.Now;

            HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);

            request.Password = hashSalt.Hash;
            request.Salt = hashSalt.Salt;

            //Since user is registering for the first time on the app, his default role will be Developer
            request.RoleId = context.Roles.FirstOrDefault(x => x.Name == "Developer").Id;
            context.Add(request);
            context.SaveChanges();


            //Send email
            SendEmailDto sendEmailDto = new SendEmailDto
            {
                SendTo = request.Email,
                Subject = "Successfull registration to Bug Tracker",
                Content = "Welcome to Bug Tracker"
            };

            _emailSender.SendEmail(sendEmailDto);
        }
    }
}
