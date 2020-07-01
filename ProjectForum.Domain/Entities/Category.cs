using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
