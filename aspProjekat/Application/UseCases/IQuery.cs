using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCases
{
    public interface IQuery<TSearch, TResult> : IUseCase
        where TResult : class
    {
        TResult Execute(TSearch search);
    }
}
