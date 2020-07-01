using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ProjectForum.Application.Queries;
using ProjectForum.Application.Searches;

namespace ProjectForum.Implementation.Extensions
{
    public static class QueryableExtensions
    {
        public static PagedResponse<TDto> Paged<TDto, TEntity>(
            this IQueryable<TEntity> query, PagedSearch search, IMapper mapper)
            where TDto : class
        {
            var skipCount = search.PerPage * (search.Page - 1);

            var skipped = query.Skip(skipCount).Take(search.PerPage);

            var response = new PagedResponse<TDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = mapper.Map<IEnumerable<TDto>>(skipped)
            };

            return response;
        }
    }
}
