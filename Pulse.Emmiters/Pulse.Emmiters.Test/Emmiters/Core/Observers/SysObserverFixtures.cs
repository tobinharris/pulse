using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Pulse.Emmiters.DotNet.Core.Observers;

namespace Pulse.Emmiters.Test.Emmiters.Core.Observers
{
    [TestFixture]
    public class SysObserverFixtures
    {
        [Test]
        public void CanRetrieveObservations()
        {
            var observer = new SysObserver();
            var observations = observer.GetObservations();
        }

    }
}
