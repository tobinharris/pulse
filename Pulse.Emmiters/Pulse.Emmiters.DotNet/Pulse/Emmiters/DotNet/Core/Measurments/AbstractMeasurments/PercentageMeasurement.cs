using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    public abstract class PercentageMeasurement : Measurement
    {
        protected PercentageMeasurement()
        {
        }

        [JsonProperty]
        public override string Unit
        {
            get { return "%"; }
        }

        public override bool IsValid()
        {
            return ((Value < 0.0) || (Value > 100.0));
        }
    }
}