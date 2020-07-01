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
    public class EfGetRepliesQuery : IGetRepliesQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetRepliesQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 307;

        public string Description => "Get Replies using EntityFrameworkCore";

        public PagedResponse<ReplyDto> Execute(ReplySearch search)
        {
            var query = _context.Replies.AsQueryable();

            if (!string.IsNullOrEmpty(search.Body) || !string.IsNullOrWhiteSpace(search.Body))
            {
                query = query.Where(reply => reply.Body.ToLower().Contains(search.Body.ToLower()));
            }

            return query.Paged<ReplyDto, Reply>(search, _mapper);
        }
    }
}
