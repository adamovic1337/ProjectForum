using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Application.Exceptions;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;
using ProjectForum.Implementation.Validators;

namespace ProjectForum.Implementation.Commands
{
    public class EfUpdateRoleCommand : IUpdateRoleCommand
    {
        private readonly ProjectForumContext _context;
        private readonly UpdateRoleValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateRoleCommand(ProjectForumContext context, IMapper mapper, UpdateRoleValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 105;

        public string Description => "Update Role using EntityFrameworkCore";

        public void Execute(RoleDto request)
        {
            if (_context.Categories.Find(request.Id) == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Reply));
            }

            _validator.ValidateAndThrow(request);

            var role = _context.Roles.Find(request.Id);

            _mapper.Map(request, role);
            _context.SaveChanges();
        }
    }
}
