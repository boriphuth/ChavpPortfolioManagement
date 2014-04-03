using Cpm.Domains.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Entities
{
    public class MeasureEvent
        : Entity
    {
        public virtual string Type { get; set; }

        public virtual DateTime? Start { get; set; }
        public virtual DateTime? End { get; set; }

        public virtual long? Effort { get; set; }
        public virtual Scale EffortUnit { get; set; }
        public virtual long? Value { get; set; }

    }
}
