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
    public class EfDeleteRoleUseCaseCommand : IDeleteRoleUseCaseCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfDeleteRoleUseCaseCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 108;

        public string Description => "SoftDelete User using EntityFrameworkCore";

        public void Execute(int request)
        {
            if (_context.RoleUseCases.Find(request) == null)
            {
                throw new EntityNotFoundException(request, typeof(RoleUseCase));
            }

            _context.Remove(_context.RoleUseCases.Find(request));
            _context.SaveChanges();
        }
    }
}
