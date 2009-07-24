using System;
using System.Threading;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments;

namespace Pulse.Emmiters.DotNet.Core.Measurments.Windows
{
    public class TimeToDoSomethingMeasurement : ActionTimeMeasurement
    {
        public TimeToDoSomethingMeasurement()
        {
            base.ActionToPerform = delegate { Thread.Sleep(new Random().Next(100)); };
        }

        [JsonProperty]
        public override string Description
        {
            get { return "Pointless metric, returning the time required for an action to run"; }
        }

        [JsonProperty]
        public override string Name
        {
            get { return "Current time"; }
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}