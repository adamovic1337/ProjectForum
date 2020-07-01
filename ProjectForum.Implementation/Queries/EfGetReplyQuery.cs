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
    public class EfGetReplyQuery : IGetReplyQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetReplyQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 308;

        public string Description => "Get Reply using EntityFrameworkCore";

        public IEnumerable<ReplyDto> Execute(int search)
        {
            var query = _context.Replies.AsQueryable();

            query = query.Where(reply => reply.Id == search);

            return query.Select(reply => _mapper.Map<ReplyDto>(reply)).ToList();
        }
    }
}
