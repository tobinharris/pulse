namespace Pulse.Emmiters.DotNet.Domain
{
    using Newtonsoft.Json;
    using System;

    public class Measurement : Observation<double>
    {
        public override bool IsValid()
        {
            return true;
        }

        [JsonProperty]
        public override string Description
        {
            get
            {
                return string.Empty;
            }
        }

        [JsonProperty]
        public override string Name
        {
            get
            {
                return string.Empty;
            }
        }

        [JsonProperty]
        public override string Unit
        {
            get
            {
                return string.Empty;
            }
        }
    }
}

