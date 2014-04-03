using Cpm.Domains.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cpm.Domains.Entities
{
    public abstract class Measurable
        : Entity
    {
        public Measurable()
        {
            EstimateEvents = new List<MeasureEvent>(); 
        }

        public virtual IList<MeasureEvent> EstimateEvents { get; protected set; }

        public virtual void Estimate(DateTime start, DateTime end)
        {
            EstimateEvents.Add(new MeasureEvent
            {
                Type = "Estimated",
                Start = start,
                End = end,
            });
        }

        public virtual void Actual(DateTime start, DateTime end)
        {
            EstimateEvents.Add(new MeasureEvent
            {
                Type = "Actual",
                Start = start,
                End = end,
            });
        }

        public virtual void Actual(DateTime start, long effort, Scale unit)
        {
            EstimateEvents.Add(new MeasureEvent
            {
                Type = "Actual",
                Start = start,
                Effort = effort,
                EffortUnit = unit
            });
        }

        public virtual void Estimate(DateTime start, long effort, Scale unit)
        {
            EstimateEvents.Add(new MeasureEvent
            {
                Type = "Estimated",
                Start = start,
                Effort = effort,
                EffortUnit = unit
            });
        }

        public virtual void ReEstimate(DateTime start, long effort, Scale unit)
        {
            EstimateEvents.Add(new MeasureEvent
            {
                Type = "Re-estimated",
                Start = start,
                Effort = effort,
                EffortUnit = unit
            });
        }

        public virtual void EstimateValue(long value)
        {
            EstimateEvents.Add(new MeasureEvent
            {
                Type = "EstimatedValue",
                Value = value,
            });
        }

        public virtual void ReEstimateValue(long value)
        {
            EstimateEvents.Add(new MeasureEvent
            {
                Type = "ReEstimatedValue",
                Value = value,
            });
        }
    }
}
