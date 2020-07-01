using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;
using ProjectForum.Implementation.Validators;

namespace ProjectForum.Implementation.Commands
{
    public class EfCreateUserCommand : ICreateUserCommand
    {
        private readonly ProjectForumContext _context;
        private readonly CreateUserValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateUserCommand(ProjectForumContext context, IMapper mapper, CreateUserValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 7;

        public string Description => "Create New User using EntityFrameworkCore";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = _mapper.Map<User>(request);

            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
