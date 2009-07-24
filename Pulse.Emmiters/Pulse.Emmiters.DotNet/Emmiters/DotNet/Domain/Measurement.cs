using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain
{
    public abstract class Measurement : Observation<double>
    {
        public override bool IsValid()
        {
            return true;
        }
    }

}