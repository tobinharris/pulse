namespace Pulse.Emmiters.DotNet.Domain.Metrics
{
    public interface IMetric<T>
    {
        /// <summary>
        /// Name of the metric
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Human readable description
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Display unit for metric
        /// </summary>
        string Unit { get; }

        /// <summary>
        /// Value of the metric
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Validate the metric's value is acceptable
        /// </summary>
        void Validate();
    }
}