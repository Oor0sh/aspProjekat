using aspProjekat.Application.UseCases.DTO;
using aspProjekat.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserValidator(aspProjekatContext context)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.")
                .Must(x => !context.Users.Any(u => u.Email == x))
                .WithMessage("Email already in use.");


            RuleFor(x => x.FirstName)
                .NotEmpty();

            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage("Password is required.");
               //.Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")
               //.WithMessage("Password doesn't meet the complexity criteria.");
        }
    }
}
