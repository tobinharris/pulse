using System;
using System.Collections.Generic;
using System.Linq;
using Pulse.Emmiters.DotNet.Core.Measurments.Windows;

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

        public Observations AddDefaultMeasurements(Node node)
        {
            typeof(AvaliableRamMeasurement).Assembly.GetTypes().Where(
                t => ((t.Namespace == "Pulse.Emmiters.DotNet.CoreMeasurments.Windows") &&
                      t.IsSubclassOf(typeof (Measurement)))).ToList().ForEach(delegate(Type t)
                                                  {
                                                      var measurment=(Measurement)Activator.CreateInstance(t);
                                                      measurment.OriginatingNode = node;
                                                      Measurements.Add(measurment);
                                                  });
            return this;
        }
    }
}