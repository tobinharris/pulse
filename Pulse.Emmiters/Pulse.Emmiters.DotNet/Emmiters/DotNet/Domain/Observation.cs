using System;
using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain
{
    public abstract class Observation
    {
        public abstract ObservationType Type { get; }

        [JsonProperty]
        public string TypeKey
        {
            get { return Type.Identifier; }
        }

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

        public abstract bool IsValid();
    }

    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Observation<valT> : Observation
    {
        [JsonProperty]
        public virtual valT Value { get; set; }
    }

    public abstract class ObservationType
    {
        public abstract string Identifier { get; }
        public abstract string Description { get; }
        public abstract string Name { get; }
        public abstract string Unit { get; }
    }
}