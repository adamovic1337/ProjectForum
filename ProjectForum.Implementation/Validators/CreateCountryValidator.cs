using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ProjectForum.Application.DataTransfer;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Validators
{
    public class CreateCountryValidator : AbstractValidator<CountryDto>
    {
        public CreateCountryValidator(ProjectForumContext context)
        {
            RuleFor(category => category.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .Must(name => !context.Countries.Any(g => g.Name == name))
                .WithMessage("Name must be unique");
        }
    }
}
