using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.FluentMapping.Mappings
{
    using Cpm.Domains.Entities;
    using FluentNHibernate.Data;
    using FluentNHibernate.Mapping;

    public abstract class EntityMap<T>
        : ClassMap<T> where T : Cpm.Domains.Entities.Entity
    {
        public EntityMap()
        {
            Id(t => t.ID, "ID");
            Id(t => t.ID).GeneratedBy.Guid();

            Map(t => t.CreatedAt).Not.Nullable();
            Map(t => t.CreatedBy).Not.Nullable();

            Version(t => t.ModifiedOn).CustomType("Timestamp");
            Map(t => t.ModifiedBy);
        }
    }
}
