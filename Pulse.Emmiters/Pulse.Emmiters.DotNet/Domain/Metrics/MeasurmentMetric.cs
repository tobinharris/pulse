using Pulse.Emmiters.DotNet.Domain.Metrics;

namespace Pulse.Emmiters.DotNet.Domain.Metrics
{
    public abstract class MeasurmentMetric : IMetric<double>
    {
        #region IMetric<double> Members

        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract string Unit { get; }

        public abstract double Value { get; }

        public virtual void Validate()
        {
            //Do nothing, parent classes to throw exception if the metric doesn't validate
        }

        #endregion
    }
}