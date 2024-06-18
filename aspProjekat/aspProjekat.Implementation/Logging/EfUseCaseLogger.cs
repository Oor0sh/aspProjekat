using aspProjekat.Application.Logging;
using aspProjekat.DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Implementation.Logging
{
    public class EfUseCaseLogger : IUseCaseLogger
    {
        private readonly aspProjekatContext _context;

        public EfUseCaseLogger(aspProjekatContext context)
        {
            _context = context;
        }

        public void Add(UseCaseLogEntry entry)
        {
            _context.LogEntries.Add(new Domain.Entities.LogEntry
            {
                User = entry.User,
                UserId = entry.UserId,
                UseCaseData = JsonConvert.SerializeObject(entry.Data),
                UseCaseName = entry.UseCaseName,
                CreatedAt = DateTime.UtcNow
            });

            _context.SaveChanges();
        }
    }
}
