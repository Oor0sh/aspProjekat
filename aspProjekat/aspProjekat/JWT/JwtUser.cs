using aspProjekat.Application;

namespace aspProjekat.API.JWT
{
    public class JwtUser : IApplicationUser
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public IEnumerable<int> AllowedUseCases { get; set; }
    }
}
