namespace Pulse.Emmiters.DotNet.Core.Measurments.Windows
{
    using Newtonsoft.Json;
    using Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments;
    using System;

    public class AvaliableRamMeasurment : AbsoluteMeasurement
    {
        public AvaliableRamMeasurment(double ramConsumptionValue)
        {
            this.Value = ramConsumptionValue;
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
                return "Details the avaliable RAM of the node";
            }
        }

        [JsonProperty]
        public override string Name
        {
            get
            {
                return "Avaliable Ram Metric";
            }
        }

        [JsonProperty]
        public override string Unit
        {
            get
            {
                return "MB";
            }
        }
    }
}

