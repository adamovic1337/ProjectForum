using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Application.Exceptions;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;
using ProjectForum.Implementation.Validators;

namespace ProjectForum.Implementation.Commands
{
    public class EfUpdateCountryCommand : IUpdateCountryCommand
    {
        private readonly ProjectForumContext _context;
        private readonly UpdateCountryValidator _validator;
        private readonly IMapper _mapper;

        public EfUpdateCountryCommand(ProjectForumContext context, IMapper mapper, UpdateCountryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 102;

        public string Description => "Update Country using EntityFrameworkCore";

        public void Execute(CountryDto request)
        {
            if (_context.Categories.Find(request.Id) == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Country));
            }

            _validator.ValidateAndThrow(request);

            var country = _context.Countries.Find(request.Id);

            _mapper.Map(request, country);
            _context.SaveChanges();
        }
    }
}
