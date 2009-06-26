using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using Pulse.Emmiters.DotNet;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.Test
{
    [TestFixture]
    public class EmitterFixture
    {
        [Test]
        [Category("Integration")]
        public void Can_Initiate_Emitter()
        {
            var feature = new Feature("My web site", "My great website");
            feature.AutoDiscoverNodes();
            var observations = new Observations().AddDefaultMeasurements(feature.Nodes[0]);

            var emmiter = new Emitter {EmitPeriod = 10000};
            emmiter.EmitterBegun += emmiter_EmitterBegun;
            emmiter.Init(feature, observations);
            Thread.Sleep(100000);
        }

        static void emmiter_EmitterBegun(IList<string> payloadJSON)
        {
            new List<string>(payloadJSON).ForEach(Console.WriteLine);
            Assert.Greater(payloadJSON.Count, 0);
        }
    }
}