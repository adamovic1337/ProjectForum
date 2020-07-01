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
    public class EfUpdateReplyCommand : IUpdateReplyCommand
    {
        private readonly ProjectForumContext _context;
        private readonly UpdateReplyValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateReplyCommand(ProjectForumContext context, IMapper mapper, UpdateReplyValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 104;

        public string Description => "Update Reply using EntityFrameworkCore";

        public void Execute(ReplyDto request)
        {
            if (_context.Categories.Find(request.Id) == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Reply));
            }

            _validator.ValidateAndThrow(request);

            var reply = _context.Replies.Find(request.Id);

            _mapper.Map(request, reply);
            _context.SaveChanges();
        }
    }
}
