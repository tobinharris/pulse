using System.Collections.Generic;
using System.Diagnostics;
using Pulse.Emmiters.DotNet.Core.Measurments.Windows;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Observers
{
    public class RamObserver : Observer
    {
        private readonly PerformanceCounter _counter = new PerformanceCounter("Memory", "Available MBytes");

        public override IList<Observation> GetObservations()
        {
            return new List<Observation> { new AvaliableRamMeasurement(_counter.NextValue()) };
        }
    }
}