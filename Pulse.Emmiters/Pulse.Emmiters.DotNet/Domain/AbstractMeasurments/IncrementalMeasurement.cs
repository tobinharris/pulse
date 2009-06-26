namespace Pulse.Emmiters.DotNet.Domain.AbstractMeasurments
{
    public abstract class IncrementalMeasurement : Measurement
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