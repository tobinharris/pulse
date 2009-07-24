namespace Pulse.Emmiters.DotNet.Domain
{
    public abstract class Observation
    {
        public abstract string Description { get; }

        public Observation Glue { get; set; }


        public abstract string Name { get; }

        public Node Node { get; set; }

        public abstract string Unit { get; }
        public abstract bool IsValid();
    }
}