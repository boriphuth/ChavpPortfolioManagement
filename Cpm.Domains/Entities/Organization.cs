using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Entities
{
    public class Organization : Entity
    {
        public Organization()
        {
            Departments = new List<Department>();
            Portfolio = new List<Project>();
        }

        public virtual string Name { get; set; }

        public virtual IList<Department> Departments { get; protected set; }

        public virtual IList<Project> Portfolio { get; set; }
    }
}
