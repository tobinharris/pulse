using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Pulse.Emmiters.DotNet.Core.Measurments.Windows;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Observers
{
    public class CpuObserver : Observer
    {
        private readonly PerformanceCounter _counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        private float GetCurrentCpuActivity()
        {
            return _counter.NextValue();
        }

        private float GetNormalCpuUsage(int timePeriod)
        {
            var cpuUsageList = new List<float>();
            var activity = 0f;
            if (timePeriod < 1)
            {
                throw new Exception("CPUUsage->GetNormalCpuUsage: TimePeriod should be more then zero");
            }
            for (var i = 0; i < timePeriod; i++)
            {
                var nextActivity = GetCurrentCpuActivity();
                if (nextActivity > 0f)
                {
                    cpuUsageList.Add(nextActivity);
                }
                Thread.Sleep(50);
            }
            cpuUsageList.ForEach(delegate(float a) { activity += a; });
            return (activity/cpuUsageList.Count);
        }

        public override IList<Observation> GetObservations()
        {
            return new List<Observation> {new CpuMeasurement(GetNormalCpuUsage(5))};
        }
    }
}