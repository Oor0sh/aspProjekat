﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Domain.Entities
{
    public class LogEntry : Entity
    {
        public string User { get; set; }
        public int UserId { get; set; }
        public string UseCaseName { get; set; }
        public string UseCaseData { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
