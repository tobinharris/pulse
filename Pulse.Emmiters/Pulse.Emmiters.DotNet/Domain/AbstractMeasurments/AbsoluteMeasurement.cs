namespace Pulse.Emmiters.DotNet.Domain.AbstractMeasurments
{
    public abstract class AbsoluteMeasurement : Measurement
    {
        public override string Unit
        {
            get { return "Absolute"; }
        }
    }
}