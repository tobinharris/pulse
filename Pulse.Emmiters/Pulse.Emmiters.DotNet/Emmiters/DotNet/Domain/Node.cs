﻿using Newtonsoft.Json;

namespace Pulse.Emmiters.DotNet.Domain
{
    [JsonObject]
    public class Node
    {
        public Node(string identifier)
        {
            Identifier = identifier;
        }

        public string Identifier { get; set; }
    }
}