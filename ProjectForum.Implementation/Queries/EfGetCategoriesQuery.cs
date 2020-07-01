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
    public class EfGetCategoriesQuery : IGetCategoriesQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetCategoriesQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 301;

        public string Description => "Get Categories using EntityFrameworkCore";

        public PagedResponse<CategoryDto> Execute(CategorySearch search)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(category => category.Name.ToLower().Contains(search.Name.ToLower()));
            }
            
            return query.Paged<CategoryDto, Category>(search, _mapper);
        }
    }
}
