using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public abstract class Observation<valT>
    {
        /// <summary>
        /// Observation needs a node from which it came.
        /// </summary>
        public virtual Node Node { get; set; }


        /// <summary>
        /// Name of the observation type (for use on the PulseBoard)
        /// </summary>
        public abstract string Unit { get; }

        /// <summary>
        /// Name of the observation type (for use on the PulseBoard)
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Human readable description  (for use on the PulseBoard)
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Observation value type is dependent upon the observation type
        /// </summary>
        public abstract valT Value { get; }


        /// <summary>
        /// Used to validate the measurment
        /// </summary>
        /// <returns></returns>
        public abstract bool IsValid();
    }
}