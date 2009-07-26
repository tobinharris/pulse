using System;
using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain
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

    public class ObservationType
    {
       public ObservationType(string identifier, string description, string name, string unit)
       {
           Identifier = identifier;
           Description = description;
           Name = name;
           Unit = unit;
       }

        public string Identifier { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}