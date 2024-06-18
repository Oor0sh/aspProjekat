using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException
            (string email, string useCaseName)
            : base($"There was an unauthorized access attempt by {email} for {useCaseName} use case.")
        {

        }
    }
}
