using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain
{
    public class Measurement : Observation<double>
    {
        [JsonProperty]
        public override string Description
        {
            get { return string.Empty; }
        }

        [JsonProperty]
        public override string Name
        {
            get { return string.Empty; }
        }

        [JsonProperty]
        public override string Unit
        {
            get { return string.Empty; }
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}