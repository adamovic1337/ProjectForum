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
    public class EfGetUseCaseLogsQuery : IGetUseCaseLogQuery
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfGetUseCaseLogsQuery(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 315;

        public string Description => "Get UseCaseLogs using EntityFrameworkCore";

        public PagedResponse<UseCaseLogDto> Execute(UseCaseLogSearch search)
        {
            var query = _context.UseCaseLogs.AsQueryable();

            switch (search.SearchBy)
            {
                case "datetime":
                    break;
                case "actor":
                    if (!string.IsNullOrEmpty(search.SearchText) || !string.IsNullOrWhiteSpace(search.SearchText))
                    {
                        query = query.Where(ucl => ucl.Actor.ToLower().Contains(search.SearchText.ToLower()));
                    }
                    break;
                case "usecasename":
                    if (!string.IsNullOrEmpty(search.SearchText) || !string.IsNullOrWhiteSpace(search.SearchText))
                    {
                        query = query.Where(ucl => ucl.UseCaseName.ToLower().Contains(search.SearchText.ToLower()));
                    }
                    break;
            }
            

            return query.Paged<UseCaseLogDto, UseCaseLog>(search, _mapper);
        }
    }
}
