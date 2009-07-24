namespace Pulse.Emmiters.DotNet.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Feature
    {
        [CompilerGenerated]
        private string <Description>k__BackingField;
        [CompilerGenerated]
        private string <Name>k__BackingField;
        [CompilerGenerated]
        private IList<Node> <Nodes>k__BackingField;

        public Feature(string name, string description)
        {
            this.Name = name;
            this.Description = description;
            this.Nodes = new List<Node>();
        }

        public Feature(string name, string description, IList<Node> nodes)
        {
            this.Name = name;
            this.Description = description;
            this.Nodes = nodes;
        }

        public Feature AutoDiscoverNodes()
        {
            this.Nodes.Add(new Node(Environment.MachineName));
            return this;
        }

        public string Description
        {
            [CompilerGenerated]
            get
            {
                return this.<Description>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Description>k__BackingField = value;
            }
        }

        public string Name
        {
            [CompilerGenerated]
            get
            {
                return this.<Name>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Name>k__BackingField = value;
            }
        }

        public IList<Node> Nodes
        {
            [CompilerGenerated]
            get
            {
                return this.<Nodes>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Nodes>k__BackingField = value;
            }
        }
    }
}

