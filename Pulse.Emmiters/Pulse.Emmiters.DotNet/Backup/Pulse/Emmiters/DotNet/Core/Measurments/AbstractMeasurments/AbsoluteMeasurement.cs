namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    using Pulse.Emmiters.DotNet.Domain;
    using System;

    public abstract class AbsoluteMeasurement : Measurement
    {
        protected AbsoluteMeasurement()
        {
        }

        public override string Unit
        {
            get
            {
                return "Absolute";
            }
        }
    }
}

