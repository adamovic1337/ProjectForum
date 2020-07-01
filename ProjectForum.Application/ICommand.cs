using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application
{
    public interface ICommand<in TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }
}
