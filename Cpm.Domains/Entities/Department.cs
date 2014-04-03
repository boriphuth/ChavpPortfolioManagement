using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Entities
{
    public class Department : Entity
    {
        public virtual string Name { get; set; }

        public virtual Organization Organization { get; protected set; }
    }
}
