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
    public class EfGetCountryQuery : IGetCountryQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetCountryQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 304;

        public string Description => "Get Country using EntityFrameworkCore";

        public IEnumerable<CountryDto> Execute(int search)
        {
            var query = _context.Countries.AsQueryable();

            query = query.Where(c => c.Id == search);

            return query.Select(country => _mapper.Map<CountryDto>(country)).ToList();
        }
    }
}
