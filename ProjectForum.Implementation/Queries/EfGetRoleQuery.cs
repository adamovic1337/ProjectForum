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
    public class EfGetRoleQuery : IGetRoleQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetRoleQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 310;

        public string Description => "Get Role using EntityFrameworkCore";

        public IEnumerable<RoleDto> Execute(int search)
        {
            var query = _context.Roles.AsQueryable();

            query = query.Where(role => role.Id == search);

            return query.Select(role => _mapper.Map<RoleDto>(role)).ToList();
        }
    }
}
