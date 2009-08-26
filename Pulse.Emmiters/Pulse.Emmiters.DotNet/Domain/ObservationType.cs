namespace Pulse.Domain
{
    public class ObservationType
    {
        public ObservationType(string identifier, string description, string name, string unit)
        {
            Identifier = identifier;
            Description = description;
            Name = name;
            Unit = unit;
        }

        public string Identifier { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
    }
}