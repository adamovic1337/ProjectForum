using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForum.Application.Exceptions
{
    public class UnauthorizedUseCaseException :Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor) 
            :base($"Actror with ID of{actor.Id} - {actor.Identity} tried to execute {useCase.Description} ")
        {
            
        }
    }
}
