using System;
using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Core.ObservationTypes;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.Measurments.MVC
{
    public sealed class ControllerTimeMeasurement : Measurement
    {
        public ControllerTimeMeasurement(string controllerAction, string controllerName, double value)
        {
            ControllerAction = controllerAction;
            ControllerName = controllerName;
            Value = value;
        }

        [JsonProperty]
        public string ControllerAction { get; set; }

        [JsonProperty]
        public string ControllerName { get; set; }

        public override ObservationType Type
        {
            get { return new ControllerTimeType(); }
        }

        public override bool IsValid()
        {
            return !String.IsNullOrEmpty(ControllerAction) && !String.IsNullOrEmpty(ControllerName);
        }
    }
}