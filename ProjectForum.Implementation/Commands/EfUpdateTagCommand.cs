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
    public class EfUpdateTagCommand : IUpdateTagCommand
    {
        private readonly ProjectForumContext _context;
        private readonly UpdateTagValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateTagCommand(ProjectForumContext context, IMapper mapper, UpdateTagValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 106;

        public string Description => "Update Tag using EntityFrameworkCore";

        public void Execute(TagDto request)
        {
            if (_context.Categories.Find(request.Id) == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Tag));
            }

            _validator.ValidateAndThrow(request);

            var tag = _context.Tags.Find(request.Id);

            _mapper.Map(request, tag);
            _context.SaveChanges();
        }
    }
}
