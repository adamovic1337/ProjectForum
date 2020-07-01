﻿using System;
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
    public class EfUpdateUserCommand : IUpdateUserCommand
    {
        private readonly ProjectForumContext _context;
        private readonly UpdateUserValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateUserCommand(ProjectForumContext context, IMapper mapper, UpdateUserValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 107;

        public string Description => "Update User using EntityFrameworkCore";

        public void Execute(UserDto request)
        {
            if (_context.Categories.Find(request.Id) == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }

            _validator.ValidateAndThrow(request);

            var user = _context.Users.Find(request.Id);

            _mapper.Map(request, user);
            _context.SaveChanges();
        }
    }
}
