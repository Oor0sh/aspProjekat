using aspProjekat.Application.Logging;
using aspProjekat.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Application.UseCaseHandling
{
    public class LoggingQueryHandler : IQueryHandler
    {
        private IQueryHandler _next;
        private IApplicationUser _user;
        private IUseCaseLogger _logger;

        public LoggingQueryHandler(IQueryHandler next, IApplicationUser user, IUseCaseLogger logger)
        {
            _next = next;
            if (next == null)
            {
                throw new ArgumentException();
            }
            _user = user;
            _logger = logger;
        }

        public TResult HandleQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search) where TResult : class
        {
            _logger.Add(new UseCaseLogEntry
            {
                User = _user.Email,
                UserId = _user.Id,
                Data = search,
                UseCaseName = query.Name
            });

            return _next.HandleQuery(query, search);
        }
    }
}
