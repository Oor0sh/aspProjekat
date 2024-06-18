using aspProjekat.Application;

namespace aspProjekat.API.JWT
{
    public class UnauthorisedUser : IApplicationUser
    {
        public int Id => 0;

        public string Email => "";

        public IEnumerable<int> AllowedUseCases => new List<int> {1,2,3,4,5, 6, 7,10 };
    }
}
