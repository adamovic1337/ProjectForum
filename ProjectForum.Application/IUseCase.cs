using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application
{
    public interface IUseCase
    {
        int Id { get; }
        string Description { get; }
    }
}
