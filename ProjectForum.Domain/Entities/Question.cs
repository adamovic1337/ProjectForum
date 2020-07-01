using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Domain.Entities
{
    public class Question : Entity
    {
        public string Title { get; set; }
        public string Body { get; set; }

        public int UserId { get; set; }
        public int CategoryId { get; set; } 
        
        public User User { get; set; }
        public Category Category { get; set; }
        public ICollection<Reply> Replies { get; set; }
        public ICollection<QuestionTag> QuestionTags { get; set; }
    }
}
