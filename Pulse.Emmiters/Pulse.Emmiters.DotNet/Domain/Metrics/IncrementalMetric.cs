using Pulse.Emmiters.DotNet.Domain.Metrics;

namespace Pulse.Emmiters.DotNet.Domain.Metrics
{
    public abstract class IncrementalMetric : MeasurmentMetric
    {
        public override string Unit
        {
            get { return "Increments"; }
        }

        /// <summary>
        /// Incremental simply increments the last counter (server-side) by 1
        /// </summary>
        public override double Value
        {
            get { return 1; }
        }
    }
}