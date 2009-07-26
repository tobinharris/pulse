using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.CustomMeasurments
{
    public sealed class OpenConnectionsMeasurement : Measurement
    {
        public OpenConnectionsMeasurement(string connectionString, double value)
            : base("SQLServer.OpenConnections", value)
        {
            ConnectionString = connectionString;
            Value = value;
        }

        [JsonProperty]
        public string ConnectionString { get; set; }
    }
}