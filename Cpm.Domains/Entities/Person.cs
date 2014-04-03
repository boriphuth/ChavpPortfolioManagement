using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Entities
{
    public class Person : Entity
    {
        public Person()
        {
            Projects = new List<Project>();
        }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual Department Department { get; set; }

        public virtual IList<Project> Projects { get; protected set; }
    }
}
