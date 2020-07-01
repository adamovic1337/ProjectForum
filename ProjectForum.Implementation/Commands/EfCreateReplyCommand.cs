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
    public class EfCreateReplyCommand : ICreateReplyCommand
    {
        private readonly ProjectForumContext _context;
        private readonly CreateReplyValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateReplyCommand(ProjectForumContext context, IMapper mapper, CreateReplyValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 4;

        public string Description => "Create New Reply using EntityFrameworkCore";

        public void Execute(ReplyDto request)
        {
            _validator.ValidateAndThrow(request);

            var reply = _mapper.Map<Reply>(request);

            _context.Replies.Add(reply);
            _context.SaveChanges(); 
        }
    }
}
