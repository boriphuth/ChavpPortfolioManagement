using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Entities
{
    public class TaskItem
        : Measurable
    {
        public TaskItem()
        {
            EstimateEvents = new List<MeasureEvent>(); 
        }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
