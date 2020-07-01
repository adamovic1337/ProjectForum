using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Application.Email;
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
        private readonly IEmailSender _sender;

        public EfCreateUserCommand(ProjectForumContext context, IMapper mapper, CreateUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 7;

        public string Description => "Create New User using EntityFrameworkCore";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = _mapper.Map<User>(request);

            _context.Users.Add(user);
            _context.SaveChanges();


            //need credentials for SmtpEmailSender class
            //_sender.Send(new SendEmailDto
            //{
            //    Content = "<h1>Welcome to ProjectForum<h1>",
            //    SendTo = request.Email,
            //    Subject = "Registration"
            //});
        }
    }
}
