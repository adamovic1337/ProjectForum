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
    public class EfGetCountriesQuery : IGetCountriesQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetCountriesQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Id => 303;

        public string Description => "Get Countries using EntityFrameworkCore";

        public PagedResponse<CountryDto> Execute(CountrySearch search)
        {
            var query = _context.Countries.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(country => country.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<CountryDto, Country>(search, _mapper);
        }
    }
}
