using System;
using Pulse.Emmiters.DotNet.Core.ObservationTypes;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Measurments.Windows
{
    public sealed class CpuMeasurement : Measurement
    {
        public CpuMeasurement(double cpuConsumptionValue)
        {
            Value = cpuConsumptionValue;
        }

        public override ObservationType Type
        {
            get { return new CpuMeasurementType(); }
        }

        public override bool IsValid()
        {
            return Value < 100 && Value > 0;
        }
    }
}