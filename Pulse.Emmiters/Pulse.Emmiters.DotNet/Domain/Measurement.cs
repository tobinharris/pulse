using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain
{
    /// <summary>
    /// Typically measurments are periodic.
    /// Sent from servers.
    /// Could be performance statistics.
    /// And status of important system objects.
    /// 
    /// </summary>
    public abstract class Measurement : Observation<double>
    {
    }



}