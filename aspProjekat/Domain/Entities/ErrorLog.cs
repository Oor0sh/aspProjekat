﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Domain.Entities
{
    public class ErrorLog
    {
        public Guid ErrorId { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        public DateTime Time { get; set; }
    }
}
