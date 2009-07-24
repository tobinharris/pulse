using Newtonsoft.Json;
using Pulse.Emmiters.DotNet.Core.Measurments.AbstractMeasurments;

namespace Pulse.Emmiters.DotNet.Core.Measurments.MVC
{
    public class ControllerTimeMeasurement : TimeMeasurement
    {
        private double _value;

        public ControllerTimeMeasurement(string controllerName, string controllerAction, double value)
        {
            ControllerName = controllerName;
            ControllerAction = controllerAction;
            _value = value;
        }

        public string ControllerAction { get; set; }
        public string ControllerName { get; set; }

        [JsonProperty]
        public override string Description
        {
            get
            {
                return string.Format("Time taken to perform the {0} action in the {1} controller", ControllerAction,
                                     ControllerName);
            }
        }

        [JsonProperty]
        public override string Name
        {
            get { return "Controller Time"; }
        }

        [JsonProperty]
        public override double Value
        {
            get { return _value; }
        }

        public override bool IsValid()
        {
            return true;
        }
    }
}