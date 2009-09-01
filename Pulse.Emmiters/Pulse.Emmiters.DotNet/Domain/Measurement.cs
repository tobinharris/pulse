namespace Pulse.Domain
{
    public class Measurement : Observation<double>
    {
        public Measurement(string typeKey)
        {
            TypeKey = typeKey;
        }
        public Measurement(string typeKey, double value) : this(typeKey)
        {
            Value = value;
        }
    }
}