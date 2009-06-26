using System;
using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain.AbstractMeasurments
{
    public abstract class ActionTimeMeasurement : TimeMeasurement
    {
        public Action ActionToPerform { get; set; }



        /// <summary>
        /// Value of the metric
        /// </summary>
        [JsonProperty]
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

    public abstract class TimeMeasurement : Measurement
    {
        public override string Unit
        {
            get { return "ms"; }
        }
    }
}