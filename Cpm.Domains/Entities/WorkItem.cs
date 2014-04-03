using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Entities
{
    public class WorkItem
        : Measurable
    {
        public WorkItem()
        {
            TaskItems = new List<TaskItem>();
        }

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual Phase Phase { get; set; }
        public virtual WorkItemType WorkItemType { get; set; }

        public virtual IList<TaskItem> TaskItems { get; set; }

    }
}