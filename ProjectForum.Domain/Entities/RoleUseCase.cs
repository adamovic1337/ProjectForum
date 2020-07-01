using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Domain.Entities
{
    public class RoleUseCase
    {
        public int Id { get; set; }
        public int UseCaseId { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
