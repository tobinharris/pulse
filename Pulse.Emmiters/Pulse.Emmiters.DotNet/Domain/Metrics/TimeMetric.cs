using System;
using Pulse.Emmiters.DotNet.Domain.Metrics;

namespace Pulse.Emmiters.DotNet.Domain.Metrics
{
    public abstract class TimeMetric : MeasurmentMetric
    {
        public Action ActionToPerform { get; set; }

        public override string Unit
        {
            get { return "Time"; }
        }

        /// <summary>
        /// Value of the metric
        /// </summary>
        public override double Value
        {
            get { return GetTimeForAction(); }
        }

        private double GetTimeForAction()
        {
            var start = DateTime.Now.Ticks;
            ActionToPerform.Invoke();
            var end = DateTime.Now.Ticks;
            return end - start;
        }

    }
}