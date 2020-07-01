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
    public class EfGetUserQuery : IGetUserQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetUserQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 314;

        public string Description => "Get User using EntityFrameworkCore";

        public IEnumerable<UserDto> Execute(int search)
        {
            var query = _context.Tags.AsQueryable();

            query = query.Where(tag => tag.Id == search);

            return query.Select(tag => _mapper.Map<UserDto>(tag)).ToList();
        }
    }
}
