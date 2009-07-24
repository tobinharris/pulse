namespace Pulse.Emmiters.DotNet.Domain
{
    using Pulse.Emmiters.DotNet.Core.Measurments.Windows;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public class Observations
    {
        [CompilerGenerated]
        private List<Event> <Events>k__BackingField;
        [CompilerGenerated]
        private List<Measurement> <Measurements>k__BackingField;

        public Observations()
        {
            this.Measurements = new List<Measurement>();
            this.Events = new List<Event>();
        }

        public Observations AddDefaultMeasurements(Node node)
        {
            typeof(AvaliableRamMeasurment).Assembly.GetTypes().Where<Type>(delegate (Type t) {
                return ((t.Namespace == "Pulse.Emmiters.DotNet.CoreMeasurments.Windows") && t.IsSubclassOf(typeof(Measurement)));
            }).ToList<Type>().ForEach(delegate (Type t) {
                Measurement measurment = (Measurement) Activator.CreateInstance(t);
                measurment.Node = node;
                this.Measurements.Add(measurment);
            });
            return this;
        }

        public List<Event> Events
        {
            [CompilerGenerated]
            get
            {
                return this.<Events>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Events>k__BackingField = value;
            }
        }

        public List<Measurement> Measurements
        {
            [CompilerGenerated]
            get
            {
                return this.<Measurements>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<Measurements>k__BackingField = value;
            }
        }
    }
}

