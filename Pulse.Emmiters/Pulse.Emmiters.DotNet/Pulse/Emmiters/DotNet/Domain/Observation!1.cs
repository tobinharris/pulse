using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Observation<valT> : Observation
    {
        [JsonProperty]
        public virtual valT Value { get; set; }
    }
}