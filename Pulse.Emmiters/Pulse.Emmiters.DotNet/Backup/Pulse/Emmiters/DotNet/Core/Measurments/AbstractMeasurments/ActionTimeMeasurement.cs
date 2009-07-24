namespace Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments
{
    using Newtonsoft.Json;
    using System;
    using System.Runtime.CompilerServices;

    public abstract class ActionTimeMeasurement : TimeMeasurement
    {
        [CompilerGenerated]
        private Action <ActionToPerform>k__BackingField;

        protected ActionTimeMeasurement()
        {
        }

        private double GetTimeForAction()
        {
            long start = DateTime.Now.Ticks;
            this.ActionToPerform();
            return (double) (DateTime.Now.Ticks - start);
        }

        public Action ActionToPerform
        {
            [CompilerGenerated]
            get
            {
                return this.<ActionToPerform>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<ActionToPerform>k__BackingField = value;
            }
        }

        [JsonProperty]
        public override double Value
        {
            get
            {
                return this.GetTimeForAction();
            }
        }
    }
}

