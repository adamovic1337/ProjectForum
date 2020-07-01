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
    public class EfGetTagsQuery : IGetTagsQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetTagsQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 311;

        public string Description => "Get Tags using EntityFrameworkCore";

        public PagedResponse<TagDto> Execute(TagSearch search)
        {
            var query = _context.Tags.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(tag => tag.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<TagDto, Tag>(search, _mapper);
        }
    }
}
