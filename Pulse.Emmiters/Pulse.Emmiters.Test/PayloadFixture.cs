using System;
using System.Collections.Generic;
using NUnit.Framework;
using Pulse.Emmiters.DotNet;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.Test
{
    [TestFixture]
    public class PayloadFixture
    {
        [Test]
        public void Can_Retrieve_JSON_PayLoad_Parts()
        {
            var feature = new Feature("My web site", "My great website");
            feature.AutoDiscoverNodes();
            var observations = new Observations().AddDefaultMeasurements(feature.Nodes[0]);
            var payload = new Payload(feature, observations);

            var JSONPayLoad = payload.JSONObservations();
            new List<string>(JSONPayLoad).ForEach(Console.WriteLine);
            Assert.Greater(JSONPayLoad.Count, 0);
        }
    }
}