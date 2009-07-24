using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.ObservationTypes
{
    public class ControllerTimeType : ObservationType
    {
        [JsonProperty]
        public override string Identifier
        {
            get { return "Controller.Time.Observation"; }
        }

        [JsonProperty]
        public override string Description
        {
            get { return "Time taken to load an ASP MVC controller"; } 
        }

        [JsonProperty]
        public override string Name
        {
            get { return "Controller Time"; }
        }

        [JsonProperty]
        public override string Unit
        {
            get { return "ms"; }
        }
    }
}