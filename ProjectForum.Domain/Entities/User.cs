using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int CountryId { get; set; }
        public int RoleId { get; set; }

        public Country Country { get; set; }
        public Role Role { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<Reply> Replies { get; set; } 
    }
}
