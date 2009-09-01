using Newtonsoft.Json;

namespace Pulse.Domain
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