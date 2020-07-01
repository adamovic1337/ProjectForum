using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ProjectForum.Application.DataTransfer;

namespace ProjectForum.Implementation.Validators
{
    public class UpdateReplyValidator : AbstractValidator<ReplyDto>
    {
        public UpdateReplyValidator()
        {
            RuleFor(r => r.Body)
                .NotEmpty()
                .WithMessage("TextBody is required parameter");

        }
    }
}
