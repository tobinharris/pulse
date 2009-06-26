using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;
[assembly: InternalsVisibleTo("Pulse.Emmiters.Test")]

namespace Pulse.Emmiters.DotNet
{
    public class Payload
    {
        public Feature Feature;
        public Observations Observations;

        public Payload(Feature Feature, Observations Observations)
        {
            this.Feature = Feature;
            this.Observations = Observations;
        }
        internal IList<string> JSONObservations()
        {
            IList<string> PayloadJSON = new List<string>();
            foreach (var measurement in Observations.Measurements)
            {
                PayloadJSON.Add(JsonConvert.SerializeObject(measurement));
            }
            return PayloadJSON;
        }
    }
}
