using System.Collections.Generic;

namespace Pulse.Emmiters.DotNet.Domain
{
    public class ObserverContext : Dictionary<string, object>
    {
        public t GetAs<t>(string key)
        {
            return (t) this[key];
        }
    }
}
