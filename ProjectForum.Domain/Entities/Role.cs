using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Domain.Entities
{
    public class Role : Entity
    {
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<RoleUseCase> RoleUseCases { get; set; }  
    }
}
