using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProjectForum.Application.Commands;
using ProjectForum.Application.Exceptions;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Commands
{
    public class EfSoftDeleteUserCommand : IDeleteUserCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfSoftDeleteUserCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 207;

        public string Description => "SoftDelete User using EntityFrameworkCore";

        public void Execute(int request)
        {
            if (_context.Categories.Find(request) == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }
            var user = _context.Users.Find(request);
            user.Id = request;

            user.IsDeleted = true;
            user.IsActive = false;
            user.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
