using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application.DataTransfer
{
    public class SendEmailDto
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string SendTo { get; set; }
    }
}
