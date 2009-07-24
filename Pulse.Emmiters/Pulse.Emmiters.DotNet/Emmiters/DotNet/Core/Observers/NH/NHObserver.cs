using System.Collections.Generic;
using Pulse.Emmiters.DotNet.Application;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Observers.NH
{
    public class NHObserver : Observer
    {
        public override bool CanRegister
        {
            get { return RegisteredAssemblies.Assemblies.Exists(a => a.GetName().Name.ToLower().Contains("nhibernate")); }
        }

        public override IList<Observation> GetObservations()
        {
            return null;
        }
    }
}