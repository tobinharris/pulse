namespace Pulse.Emmiters.DotNet.Domain
{
    using System;
    using System.Runtime.CompilerServices;

    public abstract class Observation
    {
        [CompilerGenerated]
        private Observation <Glue>k__BackingField;
        [CompilerGenerated]
        private Pulse.Emmiters.DotNet.Domain.Node <Node>k__BackingField;

        protected Observation()
        {
        }

        public abstract bool IsValid();

        public abstract string Description { get; }

        public Observation Glue
        {
            [CompilerGenerated]
            get
            {
                return this.<Glue>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Glue>k__BackingField = value;
            }
        }

        public abstract string Name { get; }

        public virtual Pulse.Emmiters.DotNet.Domain.Node Node
        {
            [CompilerGenerated]
            get
            {
                return this.<Node>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Node>k__BackingField = value;
            }
        }

        public abstract string Unit { get; }
    }
}

