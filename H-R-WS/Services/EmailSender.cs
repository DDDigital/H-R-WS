using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.CompletedTask;
        }
    }
}
