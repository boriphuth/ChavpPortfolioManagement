using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Entities
{
    public class Process : Entity
    {
        public Process()
        {
            Phases = new List<Phase>();
            WorkItemTypes = new List<WorkItemType>(); 
        }

        public virtual string Name { get; set; }
        public virtual string ShortName { get; set; }

        public virtual IList<Phase> Phases { get; protected set; }
        public virtual IList<WorkItemType> WorkItemTypes { get; protected set; }
    }
}
