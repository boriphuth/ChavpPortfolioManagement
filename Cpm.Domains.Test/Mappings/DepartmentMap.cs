using Cpm.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Test.Mappings
{
    internal class DepartmentMap
        : EntityMap<Department>
    {
        public DepartmentMap()
        {
            Table("Departments");

            Map(x => x.Name, "Name").Unique();

            References(x => x.Organization);
        }
    }
}
