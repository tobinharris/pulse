using Pulse.Emmiters.DotNet.Domain.Exceptions;

namespace Pulse.Emmiters.DotNet.Domain.Metrics
{
    public abstract class PercentageMetric : MeasurmentMetric
    {
        public override string Unit
        {
            get { return "%"; }
        }

        public override void Validate()
        {
            if (Value < 0 || Value > 100)
                throw new InvalidMetricException("Percentage metric values must fall between 0-100%");
        }
    }
}