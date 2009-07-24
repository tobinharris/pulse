namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    using Pulse.Emmiters.DotNet.Domain;
    using System;

    public abstract class TimeMeasurement : Measurement
    {
        protected TimeMeasurement()
        {
        }

        public override string Unit
        {
            get
            {
                return "ms";
            }
        }
    }
}

