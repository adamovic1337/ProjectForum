using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application.DataTransfer
{
    public class ReplyDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
    }
}
