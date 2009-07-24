using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.ObservationTypes
{
    public class OpenConnectionsType : ObservationType
    {
        [JsonProperty]
        public override string Identifier
        {
            get { return "Controller.Cpu.Observation"; }
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
            get { return "Conns"; }
        }
    }
}