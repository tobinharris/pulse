using System;
using NUnit.Framework;
using Pulse.Emmiters.DotNet.CoreMeasurments.Windows;

namespace Pulse.Emmiters.Test.CoreMeasurment.Windows
{
    [TestFixture]
    public class CPUConsumptionMetricFixture
    {
        [Test]
        public void Can_Retrieve_Current_CPU_Usage()
        {
            var cpuMetric = new CPUConsumptionMeasurement();
            var cpuUsage = cpuMetric.Value;
            
            Assert.AreEqual("CPU Consumption", cpuMetric.Name);
            Assert.IsNotNull(cpuUsage);
            Console.WriteLine(string.Format("{0}{1}", cpuUsage, cpuMetric.Unit));
            Assert.That(cpuUsage >= 0 && cpuUsage <= 100);
        }
    }
}