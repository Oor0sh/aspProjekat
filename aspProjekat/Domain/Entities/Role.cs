using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspProjekat.Domain.Entities
{
    public class Role : NamedEntity
    {
        public ICollection<RoleUseCase> RoleUseCase { get; set; }
    }
}
