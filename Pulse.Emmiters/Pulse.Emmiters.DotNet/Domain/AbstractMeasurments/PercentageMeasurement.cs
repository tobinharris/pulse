using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain.AbstractMeasurments
{
    public abstract class PercentageMeasurement : Measurement
    {
        [JsonProperty]
        public override string Unit
        {
            get { return "%"; }
        }

        public override bool IsValid()
        {
            return (Value < 0 || Value > 100);
        }
    }
}