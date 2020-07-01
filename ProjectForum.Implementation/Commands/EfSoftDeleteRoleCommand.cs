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
    public class EfSoftDeleteRoleCommand : IDeleteRoleCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfSoftDeleteRoleCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 205;

        public string Description => "SoftDelete Role using EntityFrameworkCore";

        public void Execute(int request)
        {
            if (_context.Categories.Find(request) == null)
            {
                throw new EntityNotFoundException(request, typeof(Role));
            }
            var role = _context.Roles.Find(request);
            role.Id = request;

            role.IsDeleted = true;
            role.IsActive = false;
            role.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
