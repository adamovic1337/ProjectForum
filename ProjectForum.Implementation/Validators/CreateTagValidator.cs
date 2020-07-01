using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ProjectForum.Application.DataTransfer;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Validators
{
    public class CreateTagValidator : AbstractValidator<TagDto>
    {
        public CreateTagValidator(ProjectForumContext context)
        {
            RuleFor(t => t.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .Must(name => !context.Tags.Any(t => t.Name == name))
                .WithMessage("Name must be unique");
        }
    }
}
