using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    public abstract class AbsoluteMeasurement : Measurement
    {
        public override string Unit
        {
            get { return "Absolute"; }
        }
    }
}