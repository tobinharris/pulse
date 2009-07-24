using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Measurments.Database
{
    public class OpenConnectionsMeasurment : Measurement
    {
        public OpenConnectionsMeasurment(double connections)
        {
            Value = connections;
        }

        [JsonProperty]
        public override string Description
        {
            get { return "The number of open physical database connections"; }
        }

        [JsonProperty]
        public override string Name
        {
            get { return "Database Connections"; }
        }

        [JsonProperty]
        public override string Unit
        {
            get { return "Connections"; }
        }

        public override bool IsValid()
        {
            return (Value < 1000.0);
        }
    }
}