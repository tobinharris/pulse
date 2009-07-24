using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments;

namespace Pulse.Emmiters.DotNet.Core.Measurments.Windows
{
    public class CPUMeasurement : PercentageMeasurement
    {
        public CPUMeasurement(double cpuConsumptionValue)
        {
            Value = cpuConsumptionValue;
        }

        [JsonProperty]
        public override string Description
        {
            get { return "Details the CPU Concuption of the node"; }
        }

        [JsonProperty]
        public override string Name
        {
            get { return "CPU Consumption"; }
        }
    }
}