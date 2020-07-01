using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentValidation;
using ProjectForum.Application.DataTransfer;
using ProjectForum.EfDataAccess;

namespace ProjectForum.Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(ProjectForumContext context)
        {
            RuleFor(u => u.FirstName)
                .NotEmpty()
                .WithMessage("Name is required parameter");
            
            RuleFor(u => u.LastName)
                .NotEmpty()
                .WithMessage("Name is required parameter");
            
            RuleFor(u => u.Username)
                .NotEmpty()
                .WithMessage("Username is required parameter")
                .Must(username => !context.Users.Any(u => u.Username == username))
                .WithMessage("Username must be unique")
                .MaximumLength(15)
                .WithMessage("Max length 15 characters");
            
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required parameter")
                .Must(email => !context.Users.Any(u => u.Email == email))
                .WithMessage("Email must be unique")
                .EmailAddress();

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required parameter")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})")
                .WithMessage("Password must have at least: 1 lower case letter, 1 uppercase letter, 1 number, 1 special character, min length 8 characters ");


        }
    }
}
