using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Pulse.Domain;

namespace Pulse.Observers
{
    public class SysObserver : Observer
    {
        private readonly PerformanceCounter _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private readonly PerformanceCounter _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        private readonly PerformanceCounter _threadCountCounter = new PerformanceCounter("Process", "Thread Count", CurrentProcess.ProcessName);
        private readonly PerformanceCounter _workingSetMemoryCounter = new PerformanceCounter("Process", "Working Set", CurrentProcess.ProcessName);

        private static Process CurrentProcess
        {
            get
            {
                return Process.GetCurrentProcess();
            }
        }
        public override void RegisterTypes()
        {
            PulseManager.RegisterType(new ObservationType("Core.Cpu.Usage", "Monitors the CPU usage for a node", "CPU Usage", "%"));
            PulseManager.RegisterType(new ObservationType("Core.Ram.Usage", "Monitors the RAM usage for a node", "RAM Usage", "mb"));
            PulseManager.RegisterType(new ObservationType("Core.Threads.CurrentProc", "Number of currently running threads on current process", "No. Open Threads (Current Proc)", "threads"));
            PulseManager.RegisterType(new ObservationType("Core.Memory.CurrentProc", "Amount of working set memory allocated to current process", "Working Set (Current Proc)", "K"));        
        }

        private float GetCurrentCpuActivity()
        {
            return _cpuCounter.NextValue();
        }

        private float GetNormalCpuUsage(int timePeriod)
        {
            var cpuUsageList = new List<float>();
            float activity = 0f;
            if (timePeriod < 1)
            {
                throw new Exception("CPUUsage->GetNormalCpuUsage: TimePeriod should be more then zero");
            }
            for (int i = 0; i < timePeriod; i++)
            {
                float nextActivity = GetCurrentCpuActivity();
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
            //ReqProcess = CurrentlyRunning(sProcName);

            return new List<Observation>
                       {
                           new Measurement("Core.Cpu.Usage", GetNormalCpuUsage(5)),
                           new Measurement("Core.Ram.Usage", _ramCounter.NextValue()),
                           new Measurement("Core.Threads.CurrentProc", _threadCountCounter.NextValue()),
                           new Measurement("Core.Memory.CurrentProc", _workingSetMemoryCounter.NextValue() / 1024)
                       };
        }
    }
}