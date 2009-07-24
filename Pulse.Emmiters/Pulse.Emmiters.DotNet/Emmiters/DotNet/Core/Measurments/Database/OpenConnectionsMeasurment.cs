using System;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Core.ObservationTypes;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Measurments.Database
{
    public sealed class OpenConnectionsMeasurment : Measurement
    {
        public OpenConnectionsMeasurment(double connections)
        {
            Value = connections;
        }

        public override ObservationType Type
        {
            get { return new OpenConnectionsType(); }
        }

        public override bool IsValid()
        {
            return (Value < 1000.0);
        }
    }
}