namespace Pulse.Emmiters.DotNet.Domain.Metrics
{
    public abstract class AbsoluteMetric : MeasurmentMetric
    {
        public override string Unit
        {
            get { return "Absolute"; }
        }
    }
}