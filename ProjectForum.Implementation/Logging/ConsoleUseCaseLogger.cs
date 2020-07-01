using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ProjectForum.Application;

namespace ProjectForum.Implementation.Logging
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public void Log(IUseCase useCase, IApplicationActor actor, object data)
        {
            Console.WriteLine($"{DateTime.Now}: <{actor.Identity} - {actor.Role}> is trying to execute <{useCase.Description}> using data: " +
                              $"<{JsonConvert.SerializeObject(data)}>");
            
        }
    }
}
