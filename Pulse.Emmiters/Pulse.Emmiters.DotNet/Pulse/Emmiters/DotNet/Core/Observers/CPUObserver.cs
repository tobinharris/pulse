using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Pulse.Emmiters.DotNet.Core.Measurments.Windows;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Observers
{
    public class CPUObserver : Observer
    {
        private readonly PerformanceCounter counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        private float GetCurrentCPUActivity()
        {
            return counter.NextValue();
        }

        private float GetNormalCPUUsage(int TimePeriod)
        {
            var CPUUsageList = new List<float>();
            float activity = 0f;
            if (TimePeriod < 1)
            {
                throw new Exception("CPUUsage->GetNormalCpuUsage: TimePeriod should be more then zero");
            }
            for (int i = 0; i < TimePeriod; i++)
            {
                float nextActivity = GetCurrentCPUActivity();
                if (nextActivity > 0f)
                {
                    CPUUsageList.Add(nextActivity);
                }
                Thread.Sleep(50);
            }
            CPUUsageList.ForEach(delegate(float a) { activity += a; });
            return (activity/((float) CPUUsageList.Count));
        }

        public override IList<Observation> GetObservations()
        {
            return new List<Observation> {new CPUMeasurement((double) GetNormalCPUUsage(5))};
        }
    }
}