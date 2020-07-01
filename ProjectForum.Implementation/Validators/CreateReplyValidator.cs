using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ProjectForum.Application.DataTransfer;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Validators
{
    public class CreateReplyValidator : AbstractValidator<ReplyDto>
    {
        public CreateReplyValidator()
        {
            RuleFor(r => r.Body)
                .NotEmpty()
                .WithMessage("TextBody is required parameter");

        }
    }
}
