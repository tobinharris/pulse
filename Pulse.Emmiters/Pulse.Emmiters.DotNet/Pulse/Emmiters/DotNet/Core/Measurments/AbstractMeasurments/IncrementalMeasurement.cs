using System;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    public abstract class IncrementalMeasurement : Measurement
    {
        public override string Unit
        {
            get { return "Increments"; }
        }

        public override double Value
        {
            get { return 1.0; }
            set { throw new InvalidOperationException("Incremental measurments cannot be set"); }
        }
    }
}