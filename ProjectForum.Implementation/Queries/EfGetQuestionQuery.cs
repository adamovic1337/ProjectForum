using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Application.Queries;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Queries
{
    public class EfGetQuestionQuery : IGetQuestionQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetQuestionQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 306;

        public string Description => "Get Question using EntityFrameworkCore";

        public IEnumerable<QuestionDto> Execute(int search)
        {
            var query = _context.Questions.AsQueryable();

            query = query.Where(question => question.Id == search);

            return query.Select(question => _mapper.Map<QuestionDto>(question)).ToList();
        }
    }
}
