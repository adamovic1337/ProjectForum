using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ProjectForum.Application.DataTransfer;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Validators
{
    public class UpdateRoleValidator : AbstractValidator<RoleDto>
    {
        public UpdateRoleValidator(ProjectForumContext context)
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name is required parameter")
                .Must(name => !context.Roles.Any(r => r.Name == name))
                .WithMessage("Name must be unique");
        }
    }
}
