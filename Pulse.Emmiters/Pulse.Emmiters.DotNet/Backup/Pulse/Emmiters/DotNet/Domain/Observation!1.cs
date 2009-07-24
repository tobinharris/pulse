namespace Pulse.Emmiters.DotNet.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.Runtime.CompilerServices;

    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Observation<valT> : Observation
    {
        [CompilerGenerated]
        private valT <Value>k__BackingField;

        protected Observation()
        {
        }

        [JsonProperty]
        public virtual valT Value
        {
            [CompilerGenerated]
            get
            {
                return this.<Value>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Value>k__BackingField = value;
            }
        }
    }
}

