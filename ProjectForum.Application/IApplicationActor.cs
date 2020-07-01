using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application
{
    public interface IApplicationActor
    {
        int Id { get; }
        string Identity { get; }
        string Role { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
