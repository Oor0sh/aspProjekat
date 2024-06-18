using aspProjekat.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected aspProjekatContext Context { get; }

        protected EfUseCase(aspProjekatContext context)
        {
            Context = context;
        }
    }
}
