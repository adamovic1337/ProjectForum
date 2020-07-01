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
    public class EfGetTagQuery : IGetTagQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetTagQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 312;

        public string Description => "Get Tag using EntityFrameworkCore";

        public IEnumerable<TagDto> Execute(int search)
        {
            var query = _context.Tags.AsQueryable();

            query = query.Where(tag => tag.Id == search);

            return query.Select(tag => _mapper.Map<TagDto>(tag)).ToList();
        }
    }
}
