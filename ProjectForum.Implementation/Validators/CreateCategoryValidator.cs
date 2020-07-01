using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FluentValidation;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Domain.Entities;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Validators
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDto>
    {
        
        public CreateCategoryValidator(ProjectForumContext context)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .Must(name => !context.Categories.Any(c => c.Name == name))
                .WithMessage("Name must be unique");
        }

        
    }
}
