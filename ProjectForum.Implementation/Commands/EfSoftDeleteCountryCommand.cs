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
    public class EfSoftDeleteCountryCommand : IDeleteCountryCommand
    {
        private readonly ProjectForumContext _context;
        private readonly IMapper _mapper;

        public EfSoftDeleteCountryCommand(ProjectForumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Id => 202;

        public string Description => throw new NotImplementedException();

        public void Execute(int request)
        {
            if (_context.Categories.Find(request) == null)
            {
                throw new EntityNotFoundException(request, typeof(Country));
            }
            var country = _context.Countries.Find(request);
            country.Id = request;

            country.IsDeleted = true;
            country.IsActive = false;
            country.DeletedAt = DateTime.Now;

            _context.SaveChanges();
        }
    }
}
