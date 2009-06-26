using System;
using System.Collections.Generic;

namespace Pulse.Emmiters.DotNet.Domain
{
    public class Feature
    {
        public Feature(string name, string description)
        {
            Name = name;
            Description = description;
            Nodes = new List<Node>();
        }

        public Feature(string name, string description, IList<Node> nodes)
        {
            Name = name;
            Description = description;
            Nodes = nodes;
        }

        public Feature AutoDiscoverNodes()
        {
            Nodes.Add(new Node(Environment.MachineName));
            return this;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Node> Nodes { get; set; }
    }
}