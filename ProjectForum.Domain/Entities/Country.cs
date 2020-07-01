using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Domain.Entities
{
    public class Country : Entity
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
