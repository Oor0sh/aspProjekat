using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using aspProjekat.API.DTO;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.API.Extensions
{
    public static class ValidationExtensions
    {

        public static IEnumerable<string> AllowedExtensions => new List<string>
        {
            "jpg", "jpeg", "png"
        };


        public static UnprocessableEntityObjectResult ToUnprocessableEntity(this ValidationResult result)
        {
            var errors = result.Errors.Select(x => new ClientErrorDTO
            {
                Error = x.ErrorMessage,
                Property = x.PropertyName
            });

            return new UnprocessableEntityObjectResult(errors);
        }
    }
}
