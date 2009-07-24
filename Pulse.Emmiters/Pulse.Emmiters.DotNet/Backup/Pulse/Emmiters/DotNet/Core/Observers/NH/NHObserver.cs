namespace Pulse.Emmiters.DotNet.Core.Observers.NH
{
    using Pulse.Emmiters.DotNet.Application;
    using Pulse.Emmiters.DotNet.Domain;
    using System;
    using System.Collections.Generic;

    public class NHObserver : Observer
    {
        public override IList<Observation> GetObservations()
        {
            return null;
        }

        public override bool CanRegister
        {
            get
            {
                return RegisteredAssemblies.Assemblies.Exists(delegate (Assembly a) {
                    return a.GetName().Name.ToLower().Contains("nhibernate");
                });
            }
        }
    }
}

