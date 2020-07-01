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
    public class EfGetRolesQuery : IGetRolesQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetRolesQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 309;

        public string Description => "Get Roles using EntityFrameworkCore";

        public PagedResponse<RoleDto> Execute(RoleSearch search)
        {
            var query = _context.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
            {
                query = query.Where(role => role.Name.ToLower().Contains(search.Name.ToLower()));
            }

            return query.Paged<RoleDto, Role>(search, _mapper);
        }
    }
}
