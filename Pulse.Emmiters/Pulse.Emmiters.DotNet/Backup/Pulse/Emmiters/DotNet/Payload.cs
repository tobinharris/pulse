namespace Pulse.Emmiters.DotNet
{
    using Newtonsoft.Json;
    using Pulse.Emmiters.DotNet.Domain;
    using System;
    using System.Collections.Generic;

    public class Payload
    {
        public Pulse.Emmiters.DotNet.Domain.Feature Feature;
        public Pulse.Emmiters.DotNet.Domain.Observations Observations;

        public Payload(Pulse.Emmiters.DotNet.Domain.Feature Feature, Pulse.Emmiters.DotNet.Domain.Observations Observations)
        {
            this.Feature = Feature;
            this.Observations = Observations;
        }

        internal IList<string> JSONObservations()
        {
            IList<string> PayloadJSON = new List<string>();
            foreach (Measurement measurement in this.Observations.Measurements)
            {
                PayloadJSON.Add(JsonConvert.SerializeObject(measurement));
            }
            return PayloadJSON;
        }
    }
}

