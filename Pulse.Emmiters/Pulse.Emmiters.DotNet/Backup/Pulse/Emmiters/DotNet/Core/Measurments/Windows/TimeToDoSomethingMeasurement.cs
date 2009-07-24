namespace Pulse.Emmiters.DotNet.Core.Measurments.Windows
{
    using Newtonsoft.Json;
    using Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments;
    using System;
    using System.Threading;

    public class TimeToDoSomethingMeasurement : ActionTimeMeasurement
    {
        public TimeToDoSomethingMeasurement()
        {
            base.ActionToPerform = delegate {
                Thread.Sleep(new Random().Next(100));
            };
        }

        public override bool IsValid()
        {
            return true;
        }

        [JsonProperty]
        public override string Description
        {
            get
            {
                return "Pointless metric, returning the time required for an action to run";
            }
        }

        [JsonProperty]
        public override string Name
        {
            get
            {
                return "Current time";
            }
        }
    }
}

