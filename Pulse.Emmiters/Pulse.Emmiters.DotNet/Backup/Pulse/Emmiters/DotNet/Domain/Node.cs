namespace Pulse.Emmiters.DotNet.Domain
{
    using Newtonsoft.Json;
    using System;
    using System.Runtime.CompilerServices;

    [JsonObject]
    public class Node
    {
        [CompilerGenerated]
        private string <Identifier>k__BackingField;

        public Node(string identifier)
        {
            this.Identifier = identifier;
        }

        public string Identifier
        {
            [CompilerGenerated]
            get
            {
                return this.<Identifier>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Identifier>k__BackingField = value;
            }
        }
    }
}

