namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    using Pulse.Emmiters.DotNet.Domain;
    using System;

    public abstract class IncrementalMeasurement : Measurement
    {
        protected IncrementalMeasurement()
        {
        }

        public override string Unit
        {
            get
            {
                return "Increments";
            }
        }

        public override double Value
        {
            get
            {
                return 1.0;
            }
            set
            {
                throw new InvalidOperationException("Incremental measurments cannot be set");
            }
        }
    }
}

