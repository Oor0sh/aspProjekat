using aspProjekat.Application;
using System.Collections.Generic;

namespace aspProjekat.API.DTO
{
    public class TestApplicationUser : IApplicationUser
    {
        public int Id => 0;

        public string Email => "test@aspProjekat.com";

        public IEnumerable<int> AllowedUseCases => new List<int> { 1, 2, 3,4,5,6,7,8,9};
    }
}
