using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.ObservationTypes
{
    public class AvaliableRAMType : ObservationType
	{
        [JsonProperty]
        public override string Identifier
        {
            get { return "RAM.Observation"; }
        }

        [JsonProperty]
        public override string Description
        {
            get { return "Details the avaliable RAM of the node"; }
        }

        [JsonProperty]
        public override string Name
        {
            get { return "Avaliable Ram Metric"; }
        }

        [JsonProperty]
        public override string Unit
        {
            get { return "MB"; }
        }
	}
}
