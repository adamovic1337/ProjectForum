using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using ProjectForum.Application;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly ProjectForumContext _context;

        public DatabaseUseCaseLogger(ProjectForumContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLog
            {
                Actor = actor.Identity,
                ActorRole = actor.Role,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Description
            });

            _context.SaveChanges();
        }
    }
}
