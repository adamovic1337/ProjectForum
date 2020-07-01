using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Commands
{
    public class EfCreateRoleUseCaseCommand : ICreateRoleUserCaseCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfCreateRoleUseCaseCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 8;

        public string Description => "Create New RoleUseCase using EntityFrameworkCore";

        public void Execute(RoleUseCaseDto request)
        {
            var roleUseCase = _mapper.Map<RoleUseCase>(request);

            _context.RoleUseCases.Add(roleUseCase);
            _context.SaveChanges();
        }
    }
}
