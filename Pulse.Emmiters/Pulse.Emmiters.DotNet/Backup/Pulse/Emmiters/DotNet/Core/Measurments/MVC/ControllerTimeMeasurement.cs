namespace Pulse.Emmiters.DotNet.Core.Measurments.MVC
{
    using Newtonsoft.Json;
    using Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments;
    using System;
    using System.Runtime.CompilerServices;

    public class ControllerTimeMeasurement : TimeMeasurement
    {
        [CompilerGenerated]
        private string <ControllerAction>k__BackingField;
        [CompilerGenerated]
        private string <ControllerName>k__BackingField;
        [CompilerGenerated]
        private double <iValue>k__BackingField;

        public ControllerTimeMeasurement(string controllerName, string controllerAction, double value)
        {
            this.ControllerName = controllerName;
            this.ControllerAction = controllerAction;
            this.iValue = value;
        }

        public override bool IsValid()
        {
            return true;
        }

        public string ControllerAction
        {
            [CompilerGenerated]
            get
            {
                return this.<ControllerAction>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<ControllerAction>k__BackingField = value;
            }
        }

        public string ControllerName
        {
            [CompilerGenerated]
            get
            {
                return this.<ControllerName>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<ControllerName>k__BackingField = value;
            }
        }

        [JsonProperty]
        public override string Description
        {
            get
            {
                return string.Format("Time taken to perform the {0} action in the {1} controller", this.ControllerAction, this.ControllerName);
            }
        }

        public double iValue
        {
            [CompilerGenerated]
            get
            {
                return this.<iValue>k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                this.<iValue>k__BackingField = value;
            }
        }

        [JsonProperty]
        public override string Name
        {
            get
            {
                return "Controller Time";
            }
        }

        [JsonProperty]
        public override double Value
        {
            get
            {
                return this.iValue;
            }
        }
    }
}

