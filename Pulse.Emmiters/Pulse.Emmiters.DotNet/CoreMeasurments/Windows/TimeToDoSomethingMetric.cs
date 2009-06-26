using System;
using System.Threading;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain.AbstractMeasurments;

namespace Pulse.Emmiters.DotNet.CoreMeasurments.Windows
{
    public class TimeToDoSomethingMeasurement : ActionTimeMeasurement
    {
        public TimeToDoSomethingMeasurement()
        {
            ActionToPerform = () => Thread.Sleep(new Random().Next(100));
        }

        /// <summary>
        /// Name of the metric
        /// </summary>
        [JsonProperty]
        public override string Name
        {
            get { return "Current time"; }
        }

        /// <summary>
        /// Description of the metric
        /// </summary>
        [JsonProperty]
        public override string Description
        {
            get { return "Pointless metric, returning the time required for an action to run"; }
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}