using ProjectForum.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectForum.Api.Core
{
    
    public class AdminFakeApiActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity => "administrator";

        public string Role => "Admin";

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1, 1000);

        
    }
}
