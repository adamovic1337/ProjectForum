using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Domain.Entities
{
    public class Tag : Entity
    {
        public string Name { get; set; }

        public virtual ICollection<QuestionTag> TagQuestions { get; set; } 
    }
}
