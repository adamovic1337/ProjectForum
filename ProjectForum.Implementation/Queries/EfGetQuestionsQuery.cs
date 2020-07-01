using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Application.Queries;
using ProjectForum.Application.Searches;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;
using ProjectForum.Implementation.Extensions;

namespace ProjectForum.Implementation.Queries
{
    public class EfGetQuestionsQuery : IGetQuestionsQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetQuestionsQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 305;

        public string Description => "Get Questions using EntityFrameworkCore";

        public PagedResponse<QuestionDto> Execute(QuestionSearch search)
        {
            var query = _context.Questions.AsQueryable();

            if (!string.IsNullOrEmpty(search.Title) || !string.IsNullOrWhiteSpace(search.Title))
            {
                query = query.Where(question => question.Title.ToLower().Contains(search.Title.ToLower()));
            }

            return query.Paged<QuestionDto, Question>(search, _mapper);
        }
    }
}
