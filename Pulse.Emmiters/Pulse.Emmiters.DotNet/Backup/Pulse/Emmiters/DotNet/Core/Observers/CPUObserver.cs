namespace Pulse.Emmiters.DotNet.Core.Observers
{
    using Pulse.Emmiters.DotNet.Core.Measurments.Windows;
    using Pulse.Emmiters.DotNet.Domain;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    public class CPUObserver : Observer
    {
        private readonly PerformanceCounter counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        private float GetCurrentCPUActivity()
        {
            return this.counter.NextValue();
        }

        private float GetNormalCPUUsage(int TimePeriod)
        {
            List<float> CPUUsageList = new List<float>();
            float activity = 0f;
            if (TimePeriod < 1)
            {
                throw new Exception("CPUUsage->GetNormalCpuUsage: TimePeriod should be more then zero");
            }
            for (int i = 0; i < TimePeriod; i++)
            {
                float nextActivity = this.GetCurrentCPUActivity();
                if (nextActivity > 0f)
                {
                    CPUUsageList.Add(nextActivity);
                }
                Thread.Sleep(50);
            }
            CPUUsageList.ForEach(delegate (float a) {
                activity += a;
            });
            return (activity / ((float) CPUUsageList.Count));
        }

        public override IList<Observation> GetObservations()
        {
            List<Observation> <>g__initLocal0 = new List<Observation>();
            <>g__initLocal0.Add(new CPUMeasurement((double) this.GetNormalCPUUsage(5)));
            return <>g__initLocal0;
        }
    }
}

