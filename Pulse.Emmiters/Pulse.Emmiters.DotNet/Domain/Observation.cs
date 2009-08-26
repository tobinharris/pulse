using System;
using Newtonsoft.Json;

namespace Pulse.Domain
{
    public abstract class Observation
    {
        [JsonProperty]
        public string TypeKey { get; set; }
        
        [JsonProperty]
        public string ApiKey { get; set; }

        [JsonProperty]
        public Observation ParentObservation { get; set; }

        [JsonProperty]
        public Node OriginatingNode { get; set; }

        [JsonProperty]
        public Node ParentNode { get; set; }

        [JsonProperty]
        public DateTime TimeStamp
        {
            get { return DateTime.Now; }
        }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Observation<valT> : Observation
    {
        [JsonProperty]
        public virtual valT Value { get; set; }
    }
}