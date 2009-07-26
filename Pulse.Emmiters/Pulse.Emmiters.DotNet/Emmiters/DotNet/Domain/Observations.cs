using System;
using System.Collections.Generic;
using System.Linq;

namespace Pulse.Emmiters.DotNet.Domain
{
    public class Observations
    {
        public Observations()
        {
            Measurements = new List<Measurement>();
           // Events = new List<Event>();
        }

        //public List<Event> Events { get; set; }
        public List<Measurement> Measurements { get; set; }
    }
}