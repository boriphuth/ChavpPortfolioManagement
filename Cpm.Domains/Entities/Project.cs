using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Entities
{
    public class Project : Entity
    {
        public Project()
        {
            Peplo = new List<Person>();
            WorkItems = new List<WorkItem>();
        }

        public virtual string Code { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Person> Peplo { get; protected set; }

        public virtual Organization Organization { get; set; }

        public virtual Process Process { get; set; }

        public virtual IList<WorkItem> WorkItems { get; set; }
    }
}
