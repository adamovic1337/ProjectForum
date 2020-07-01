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
    public class EfCreateQuestionCommand : ICreateQuestionCommand
    {
        private readonly ProjectForumContext _context;
        private readonly CreateQuestionValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateQuestionCommand(ProjectForumContext context, IMapper mapper, CreateQuestionValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 3;

        public string Description => "Create New Question using EntityFrameworkCore";

        public void Execute(QuestionDto request)
        {
            _validator.ValidateAndThrow(request);

            var question = _mapper.Map<Question>(request);
            
            _context.Questions.Add(question);
            _context.SaveChanges();

            AddQuestionTags(request, question);
        }

        
        public void AddQuestionTags(QuestionDto dto, Question question)
        {
            foreach (var t in dto.TagList)
            {
                _context.QuestionTag.Add(new QuestionTag
                {
                    QuestionId = question.Id,
                    TagId = t.Id
                });
            }
            _context.SaveChanges();
        }

    }
}
