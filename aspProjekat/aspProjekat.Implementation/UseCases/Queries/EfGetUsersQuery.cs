using aspProjekat.Application.UseCases.DTO;
using aspProjekat.Application.UseCases.Queries;
using aspProjekat.Application.UseCases.Queries.Searches;
using aspProjekat.DataAccess;
using aspProjekat.Domain.Entities;
using aspProjekat.Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.UseCases.Queries
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public EfGetUsersQuery(aspProjekatContext context) : base(context)
        {
        }

        public int Id => 6;

        public string Name => "Search users";

        public PagedResponse<UserDTO> Execute(UserSearch search)
        {
            IQueryable<User> query = Context.Users;

            return query.ToPagedResponse<User, UserDTO>(search, x => new UserDTO
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    Id = x.Id,
                    LastName = x.LastName,
                    RoleId = x.RoleId,
                    RoleName = x.Role.Name,
                    Password = x.Password
                }
            );
        }
    }
}
