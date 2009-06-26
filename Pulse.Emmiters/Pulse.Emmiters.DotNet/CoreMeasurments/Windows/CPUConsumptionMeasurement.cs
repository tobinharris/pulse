using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain.AbstractMeasurments;

namespace Pulse.Emmiters.DotNet.CoreMeasurments.Windows
{
    public class CPUConsumptionMeasurement : PercentageMeasurement
    {
        /// <summary>
        /// Name of the metric
        /// </summary>
        [JsonProperty]
        public override string Name
        {
            get { return "CPU Consumption"; }
        }

        /// <summary>
        /// Description of the metric
        /// </summary>
        [JsonProperty]
        public override string Description
        {
            get { return "Details the CPU Concuption of the node"; }
        }

        /// <summary>
        /// Value of the metric
        /// </summary>
        [JsonProperty]
        public override double Value
        {
            get { return GetNormalCPUUsage(30); }
        }

        private readonly PerformanceCounter counter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        /// <summary>
        /// CPU activity in %
        /// </summary>
        /// <returns></returns>
        private float GetCurrentCPUActivity()
        {
            return counter.NextValue();
        }

        /// <summary>
        /// Returns average CPU activity during a defined period of time
        /// </summary>
        /// <param name="TimePeriod"></param>
        /// <returns></returns>
        private float GetNormalCPUUsage(int TimePeriod)
        {
            var CPUUsageList = new List<float>();

            float activity = 0;
            if (TimePeriod < 1)
                throw new Exception("CPUUsage->GetNormalCpuUsage: TimePeriod should be more then zero");

            for (var i = 0; i < TimePeriod; i++)
            {
                var nextActivity = GetCurrentCPUActivity();
                if (nextActivity > 0)
                    CPUUsageList.Add(nextActivity);
                Thread.Sleep(50);
            }
            CPUUsageList.ForEach(a => activity += a);
            return (activity / CPUUsageList.Count);
        }
    }
}