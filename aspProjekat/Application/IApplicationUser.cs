using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application
{
    public interface IApplicationUser
    {
        int Id { get; }
        string Email { get; }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
