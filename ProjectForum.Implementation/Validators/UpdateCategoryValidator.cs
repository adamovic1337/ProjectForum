using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ProjectForum.Application.DataTransfer;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<CategoryDto>
    {

        public UpdateCategoryValidator(ProjectForumContext context)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .Must(name => !context.Categories.Any(c => c.Name == name))
                .WithMessage("Name must be unique");
        }


    }
}
