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
using Application.Email;
using Application.Dto;

namespace Implementation.EfCommands.EfApplicationUserCommands
{
    public class EfAddApplicationUserCommand : BaseUseCase, IAddApplicationUserCommand
    {
        private readonly IEmailSender _emailSender;

        public EfAddApplicationUserCommand(BugTrackerContext context
            , IEmailSender emailSender) : base(context)
        {
            _emailSender = emailSender;
        }

        public int Id => 14;

        public string Name => "Add applicationUser";

        public void Execute(ApplicationUser request)
        {
            request.CreatedAt = DateTime.Now;

            HashSalt hashSalt = Password.GenerateSaltedHash(64, request.Password);

            request.Password = hashSalt.Hash;
            request.Salt = hashSalt.Salt;

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
