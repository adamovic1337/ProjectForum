using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.EfDataAccess;
using ProjectForum.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using ProjectForum.Implementation.Validators;

namespace ProjectForum.Implementation.Commands
{
    public class EfCreateRoleCommand : ICreateRoleCommand
    {
        private readonly ProjectForumContext _context;
        private readonly CreateRoleValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateRoleCommand(ProjectForumContext context, IMapper mapper, CreateRoleValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 5;

        public string Description => "Create New Role using EntityFrameworkCore";

        public void Execute(RoleDto request)
        {
            _validator.ValidateAndThrow(request);

            var role = _mapper.Map<Role>(request);

            _context.Roles.Add(role);
            _context.SaveChanges();
        }
    }
}
