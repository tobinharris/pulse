namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    using Newtonsoft.Json;
    using Pulse.Emmiters.DotNet.Domain;
    using System;

    public abstract class PercentageMeasurement : Measurement
    {
        protected PercentageMeasurement()
        {
        }

        public override bool IsValid()
        {
            return ((this.Value < 0.0) || (this.Value > 100.0));
        }

        [JsonProperty]
        public override string Unit
        {
            get
            {
                return "%";
            }
        }
    }
}

