using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.FluentMapping.Mappings
{
    using Cpm.Domains.Entities;

    public class PersonMap
        : EntityMap<Person>
    {
        public PersonMap()
        {
            Table("Peplo");

            Map(x => x.FirstName, "FirstName").UniqueKey("FullName");
            Map(x => x.LastName, "LastName").UniqueKey("FullName");

            References(x => x.Department);
            HasManyToMany(x => x.Projects);
        }
    }
}
