﻿using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Email
{
    public interface IEmailSender
    {
        public void SendEmail(SendEmailDto sendEmailDto);
    }
}
