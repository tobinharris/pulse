using System.Collections.Generic;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet
{
    public class Payload
    {
        public Feature Feature;
        public Observations Observations;

        public Payload(Feature feature, Observations observations)
        {
            Feature = feature;
            Observations = observations;
        }

        internal IList<string> JSONObservations()
        {
            IList<string> payloadJSON = new List<string>();
            foreach (var measurement in Observations.Measurements)
            {
                payloadJSON.Add(JsonConvert.SerializeObject(measurement));
            } 
            return payloadJSON;
        }
    }
}