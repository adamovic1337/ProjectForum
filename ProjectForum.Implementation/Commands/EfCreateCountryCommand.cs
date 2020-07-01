using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using FluentValidation;
using ProjectForum.Application.Commands;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;
using ProjectForum.Implementation.Validators;

namespace ProjectForum.Implementation.Commands
{
    public class EfCreateCountryCommand : ICreateCountryCommand
    {
        private readonly ProjectForumContext _context;
        private readonly CreateCountryValidator _validator;
        private readonly IMapper _mapper;

        public EfCreateCountryCommand(ProjectForumContext context, IMapper mapper, CreateCountryValidator validator)
        {
            _context = context;
            _mapper = mapper;
            _validator = validator;
        }

        public int Id => 2;

        public string Description => "Create New Country using EntityFrameworkCore";

        public void Execute(CountryDto request)
        {
            _validator.ValidateAndThrow(request);

            var country = _mapper.Map<Country>(request);

            _context.Countries.Add(country);
            _context.SaveChanges();
        }
    }
}
