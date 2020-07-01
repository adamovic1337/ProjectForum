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
    public class EfUpdateQuestionCommand : IUpdateQuestionCommand
    {
        private readonly ProjectForumContext _context;
        private readonly UpdateQuestionValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateQuestionCommand(ProjectForumContext context, IMapper mapper, UpdateQuestionValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 103;

        public string Description => "Update Question using EntityFrameworkCore";

        public void Execute(QuestionDto request)
        {
            if (_context.Categories.Find(request.Id) == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Question));
            }

            _validator.ValidateAndThrow(request);

            var question = _context.Questions.Find(request.Id);

            _mapper.Map(request, question);
            _context.SaveChanges();
        }
    }
}
