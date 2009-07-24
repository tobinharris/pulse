using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments;

namespace Pulse.Emmiters.DotNet.Core.Measurments.Windows
{
    public class AvaliableRamMeasurment : AbsoluteMeasurement
    {
        public AvaliableRamMeasurment(double ramConsumptionValue)
        {
            Value = ramConsumptionValue;
        }

        [JsonProperty]
        public override string Description
        {
            get { return "Details the avaliable RAM of the node"; }
        }

        [JsonProperty]
        public override string Name
        {
            get { return "Avaliable Ram Metric"; }
        }

        [JsonProperty]
        public override string Unit
        {
            get { return "MB"; }
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}