using System.Collections.Generic;
using System.Threading;
using Pulse.Emmiters.DotNet;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet
{
    public class Emitter
    {
        public delegate void EmitterBegunDelegate(IList<string> payloadJSON);
        public event EmitterBegunDelegate EmitterBegun;

        public int EmitPeriod { get; set; }
        private Timer Timer;

        public void Init(Feature Feature, Observations Observations)
        {
            Timer = new Timer(BeginEmmit, new Payload(Feature, Observations), 0, EmitPeriod);
            Timer.InitializeLifetimeService();
        }

        private void BeginEmmit(object state)
        {
            var payload = (Payload)state;
            EmitterBegun.Invoke(payload.JSONObservations());
        }
    }

}
