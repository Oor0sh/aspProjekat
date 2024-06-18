using aspProjekat.Application.Uploads;
using aspProjekat.Application.UseCases.Commands;
using aspProjekat.Application.UseCases.DTO;
using aspProjekat.DataAccess;
using aspProjekat.Domain.Entities;
using aspProjekat.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.UseCases.Commands
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        public EfRegisterUserCommand(aspProjekatContext context,
                                     RegisterUserValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 10;

        public string Name => "User registration";

        public void Execute(RegisterUserDTO request)
        {
            _validator.ValidateAndThrow(request);

            int defaultRole = 2;

            //1 == admin
            //2 == user

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                RoleId = defaultRole,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            Context.Users.Add(user);

            Context.SaveChanges();
        }
    }
}
