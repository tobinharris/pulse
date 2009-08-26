using Newtonsoft.Json;
using Pulse.Domain;

namespace Pulse.Observers.Common.Measurments
{
    public class HeartbeatMeasurment : Measurement
    {
        [JsonProperty]
        public string LifeForce { get; set; }

        public HeartbeatMeasurment(string lifeForce)
            : base("Common.Heartbeat", 1)
        {
            LifeForce = lifeForce;
        }
    }
}