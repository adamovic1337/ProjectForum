using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Application.Queries;
using ProjectForum.Application.Searches;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Queries
{
    public class EfGetCategoryQuery : IGetCategoryQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetCategoryQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 302;

        public string Description => "Get Category using EntityFrameworkCore";


        public IEnumerable<CategoryDto> Execute(int search)
        {
            var query = _context.Categories.AsQueryable();

            query = query.Where(c => c.Id == search);

            return query.Select(category => _mapper.Map<CategoryDto>(category)).ToList();
        }

        
    }
}
