namespace Pulse.Emmiters.DotNet.Core.Measurments.Database
{
    using Newtonsoft.Json;
    using Pulse.Emmiters.DotNet.Domain;
    using System;

    public class OpenConnectionsMeasurment : Measurement
    {
        public OpenConnectionsMeasurment(double connections)
        {
            this.Value = connections;
        }

        public override bool IsValid()
        {
            return (this.Value < 1000.0);
        }

        [JsonProperty]
        public override string Description
        {
            get
            {
                return "The number of open physical database connections";
            }
        }

        [JsonProperty]
        public override string Name
        {
            get
            {
                return "Database Connections";
            }
        }

        [JsonProperty]
        public override string Unit
        {
            get
            {
                return "Connections";
            }
        }
    }
}

