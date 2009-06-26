using System;
using System.Collections.Generic;
using System.Linq;
using Pulse.Emmiters.DotNet.CoreMeasurments.Windows;

namespace Pulse.Emmiters.DotNet.Domain
{
    public class Observations
    {
        public List<Measurement> Measurements { get; set; }
        public List<Event> Events { get; set; }

        public Observations()
        {
            Measurements = new List<Measurement>();
            Events = new List<Event>();
        }

        public Observations AddDefaultMeasurements(Node node)
        {
            typeof(AvaliableRamMeasurment)
                .Assembly
                .GetTypes()
                .Where(t => t.Namespace == "Pulse.Emmiters.DotNet.CoreMeasurments.Windows" && t.IsSubclassOf(typeof(Measurement)))
                .ToList()
                .ForEach(t =>{

                                var measurment = (Measurement)Activator.CreateInstance(t);
                                measurment.Node = node;
                                Measurements.Add(measurment);
                });
            return this;
        }
    }
}