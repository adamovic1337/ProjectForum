using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectForum.Application;

namespace ProjectForum.API.Core.JWT
{
    public class JwtActor : IApplicationActor
    {
        public int Id { get; set; }

        public string Identity { get; set; }

        public string Role { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }

        
    }
}
