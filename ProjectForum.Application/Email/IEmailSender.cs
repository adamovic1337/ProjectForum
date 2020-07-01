using System;
using System.Collections.Generic;
using System.Text;
using ProjectForum.Application.DataTransfer;

namespace ProjectForum.Application.Email
{
    public interface IEmailSender
    {
        void Send(SendEmailDto dto);
    }
}
