using System.Diagnostics;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain.AbstractMeasurments;


namespace Pulse.Emmiters.DotNet.CoreMeasurments.Windows
{
    public class AvaliableRamMeasurment : AbsoluteMeasurement
    {
        [JsonProperty]
        public override string Name
        {
            get { return "Avaliable Ram Metric"; }
        }
        [JsonProperty]
        public override string Description
        {
            get { return "Details the avaliable RAM of the node"; }
        }

        [JsonProperty]
        public override string Unit
        {
            get
            {
                return "MB";
            }
        }
        [JsonProperty]
        public override double Value
        {
            get { return counter.NextValue(); }
        }

        public override bool IsValid()
        {
            return true;
        }

        private readonly PerformanceCounter counter =  new PerformanceCounter("Memory", "Available MBytes");

    }
}