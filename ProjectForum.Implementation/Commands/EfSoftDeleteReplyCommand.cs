using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProjectForum.Application.Commands;
using ProjectForum.Application.Exceptions;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Commands
{
    public class EfSoftDeleteReplyCommand : IDeleteReplyCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfSoftDeleteReplyCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 204;

        public string Description => "SoftDelete Reply using EntityFrameworkCore";

        public void Execute(int request)
        {
            if (_context.Categories.Find(request) == null)
            {
                throw new EntityNotFoundException(request, typeof(Reply));
            }
            var reply = _context.Replies.Find(request);
            reply.Id = request;

            reply.IsDeleted = true;
            reply.IsActive = false;
            reply.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
