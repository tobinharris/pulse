namespace Pulse.Emmiters.DotNet.Core.Observers
{
    using Pulse.Emmiters.DotNet.Core.Measurments.Windows;
    using Pulse.Emmiters.DotNet.Domain;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class RamObserver : Observer
    {
        private readonly PerformanceCounter counter = new PerformanceCounter("Memory", "Available MBytes");

        public override IList<Observation> GetObservations()
        {
            List<Observation> <>g__initLocal0 = new List<Observation>();
            <>g__initLocal0.Add(new AvaliableRamMeasurment((double) this.counter.NextValue()));
            return <>g__initLocal0;
        }
    }
}

