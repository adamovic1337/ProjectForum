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
    public class EfGetRoleUseCaseQuery : IGetRoleUseCaseQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetRoleUseCaseQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 315;

        public string Description => "Get RoleUseCases using EntityFrameworkCore";

        public PagedResponse<RoleUseCaseDto> Execute(RoleUseCaseSearch search)
        {
            var query = _context.RoleUseCases.AsQueryable();

            query = query.Where(ruc => ruc.UseCaseId == search.UseCaseId);

            return query.Paged<RoleUseCaseDto, RoleUseCase>(search, _mapper);
        }
    }
}
