using System;
using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    public abstract class ActionTimeMeasurement : TimeMeasurement
    {
        protected ActionTimeMeasurement()
        {
        }

        public Action ActionToPerform { get; set; }


        [JsonProperty]
        public override double Value
        {
            get { return GetTimeForAction(); }
        }

        private double GetTimeForAction()
        {
            long start = DateTime.Now.Ticks;
            ActionToPerform();
            return (double) (DateTime.Now.Ticks - start);
        }
    }
}