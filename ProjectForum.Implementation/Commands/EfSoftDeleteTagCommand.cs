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
    public class EfSoftDeleteTagCommand : IDeleteTagCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfSoftDeleteTagCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public void Execute(int request)
        {
            if (_context.Categories.Find(request) == null)
            {
                throw new EntityNotFoundException(request, typeof(Tag));
            }
            var tag = _context.Tags.Find(request);
            tag.Id = request;

            tag.IsDeleted = true;
            tag.IsActive = false;
            tag.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
