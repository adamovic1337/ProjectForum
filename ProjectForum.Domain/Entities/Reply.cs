using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectForum.Domain.Entities
{
    public class Reply : Entity
    {
        public string Body { get; set; }

        public int UserId { get; set; }
        public int QuestionId { get; set; }

        public User User { get; set; }
        public Question Question { get; set; }
    }
}
