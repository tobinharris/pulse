using System;
using NUnit.Framework;
using Pulse.Emmiters.DotNet.CoreMeasurments.Windows;


namespace Pulse.Emmiters.Test.CoreMeasurment.Windows
{
    [TestFixture]
    public class AvaliableRamMetricFixture
    {
        [Test]
        public void Can_Retrieve_Current_Avaliable_RAM()
        {
            var ramMetric = new AvaliableRamMeasurment();
            var ramAvaliable = ramMetric.Value;

            Assert.AreEqual("Avaliable Ram Metric", ramMetric.Name);
            Assert.IsNotNull(ramAvaliable);
            Console.WriteLine(string.Format("{0}{1}", ramAvaliable, ramMetric.Unit));
            Assert.That(ramAvaliable >= 0);
        }

    }
}