using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProjectForum.Application.Commands;
using ProjectForum.Application.Exceptions;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Commands
{
    public class EfSoftDeleteQuestionCommand : IDeleteQuestionCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfSoftDeleteQuestionCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 203;

        public string Description => "SoftDelete Question using EntityFrameworkCore";

        public void Execute(int request)
        {
            if (_context.Categories.Find(request) == null)
            {
                throw new EntityNotFoundException(request, typeof(Question));
            }
            var question = _context.Questions.Find(request);
            question.Id = request;

            question.IsDeleted = true;
            question.IsActive = false;
            question.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
