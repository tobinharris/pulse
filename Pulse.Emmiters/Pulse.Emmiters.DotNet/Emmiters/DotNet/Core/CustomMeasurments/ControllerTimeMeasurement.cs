using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Domain;

namespace Pulse.Emmiters.DotNet.Core.CustomMeasurments
{
    public sealed class ControllerTimeMeasurement : Measurement
    {
        public ControllerTimeMeasurement(string controllerAction, string controllerName, double value)
            : base("MVC.Controller.Time", value)
        {
            ControllerAction = controllerAction;
            ControllerName = controllerName;
            Value = value;
        }

        [JsonProperty]
        public string ControllerAction { get; set; }

        [JsonProperty]
        public string ControllerName { get; set; }
    }
}