using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.ObservationTypes
{
    public class CpuMeasurementType : ObservationType
    {
        [JsonProperty]
        public override string Identifier
        {
            get { return "Controller.Cpu.Observation"; }
        }

        [JsonProperty]
        public override string Description
        {
            get { return "Current CPU spike"; } 
        }

        [JsonProperty]
        public override string Name
        {
            get { return "CPU Usage"; }
        }

        [JsonProperty]
        public override string Unit
        {
            get { return "%"; }
        }
    }
}