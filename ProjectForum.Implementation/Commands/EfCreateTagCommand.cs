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
    public class EfCreateTagCommand : ICreateTagCommand
    {
        private readonly ProjectForumContext _context;
        private readonly CreateTagValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateTagCommand(ProjectForumContext context, IMapper mapper, CreateTagValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 6;

        public string Description => "Create New Tag using EntityFrameworkCore";

        public void Execute(TagDto request)
        {
            _validator.ValidateAndThrow(request);

            var tag = _mapper.Map<Tag>(request);

            _context.Tags.Add(tag);
            _context.SaveChanges();
        }
    }
}
