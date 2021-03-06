﻿using System.Threading.Tasks;

namespace H_R_WS.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}