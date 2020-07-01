using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Application.Exceptions;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Commands
{
    public class EfUpdateRoleUseCaseCommand : IUpdateRoleUseCaseCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfUpdateRoleUseCaseCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 208;

        public string Description => "Update RoleUseCase using EntityFrameworkCore";

        public void Execute(RoleUseCaseDto request)
        {
            if (_context.RoleUseCases.Find(request.Id) == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(RoleUseCase));
            }
            
            var category = _context.RoleUseCases.Find(request.Id);

            _mapper.Map(request, category);
            _context.SaveChanges();
        }
    }
}
