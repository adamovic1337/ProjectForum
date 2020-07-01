using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ProjectForum.Application.Commands;
using ProjectForum.Application.Exceptions;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Commands
{
    public class EfSoftDeleteCategoryCommand : IDeleteCategoryCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfSoftDeleteCategoryCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 201;

        public string Description => "SoftDelete Category using EntityFrameworkCore";

        public void Execute(int request)
        {
            if (_context.Categories.Find(request) == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }
            var category = _context.Categories.Find(request);
            category.Id = request;

            category.IsDeleted = true;
            category.IsActive = false;
            category.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
