using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application
{
    public interface IUseCaseLogger
    {
        void Log(IUseCase useCase, IApplicationActor actor, object useCaseData);

    }
}
