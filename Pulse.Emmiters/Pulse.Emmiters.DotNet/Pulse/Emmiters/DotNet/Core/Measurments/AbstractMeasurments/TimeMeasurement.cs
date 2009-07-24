using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    public abstract class TimeMeasurement : Measurement
    {
        public override string Unit
        {
            get { return "ms"; }
        }
    }
}