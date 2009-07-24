using Pulse.Emmiters.DotNet.Core.ObservationTypes;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Measurments.Windows
{
    public sealed class AvaliableRamMeasurement : Measurement 
    {
        public AvaliableRamMeasurement(double ramConsumptionValue)
        {
            Value = ramConsumptionValue;
        }

        public override ObservationType Type
        {
            get { return new AvaliableRAMType(); }
        }
    }
}