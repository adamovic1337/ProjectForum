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
    public class EfCreateCategoryCommand : ICreateCategoryCommand
    {
        private readonly ProjectForumContext _context;
        private readonly CreateCategoryValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCategoryCommand(ProjectForumContext context, IMapper mapper, CreateCategoryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 1;

        public string Description => "Create New Category using EntityFrameworkCore";

        public void Execute(CategoryDto request)
        {
            _validator.ValidateAndThrow(request);

            var category = _mapper.Map<Category>(request);

            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
