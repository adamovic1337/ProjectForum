using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application.DataTransfer
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CountryId { get; set; }
        public int RoleId { get; set; }
    }
}
