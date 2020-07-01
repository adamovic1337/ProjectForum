using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ProjectForum.Application.DataTransfer;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Validators
{
    public class UpdateQuestionValidator : AbstractValidator<QuestionDto>
    {
        public UpdateQuestionValidator(ProjectForumContext context)
        {
            RuleFor(q => q.Title)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .Must(title => !context.Questions.Any(q => q.Title == title))
                .WithMessage("Name must be unique");

            RuleFor(q => q.Body)
                .NotEmpty()
                .WithMessage("Name is required parameter");
        }
    }
}
