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
    public class EfUpdateCategoryCommand : IUpdateCategoryCommand
    {
        private readonly ProjectForumContext _context;
        private readonly UpdateCategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateCategoryCommand(ProjectForumContext context, IMapper mapper, UpdateCategoryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 101;

        public string Description => "Update Category using EntityFrameworkCore";

        public void Execute(CategoryDto request)
        {
            if (_context.Categories.Find(request.Id) == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Category));
            }

            _validator.ValidateAndThrow(request);

            var category = _context.Categories.Find(request.Id);

            _mapper.Map(request, category);
            _context.SaveChanges();

        }
    }
}
