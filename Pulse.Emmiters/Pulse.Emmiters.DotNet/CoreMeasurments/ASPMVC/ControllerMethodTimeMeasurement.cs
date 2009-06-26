using System.Web.Mvc;
using Pulse.Emmiters.DotNet.Domain.AbstractMeasurments;

namespace Pulse.Emmiters.DotNet.CoreMeasurments.ASPMVC
{
    public class ControllerMethodTimeMeasurement : TimeMeasurement
    {
        public string ControllerName { get; set; }
        public string ControllerAction { get; set; }
        public double iValue { get; set; }
        public ControllerMethodTimeMeasurement(string controllerName, string controllerAction, double value)
        {
            ControllerName = controllerName;
            ControllerAction = controllerAction;
            iValue = value;
        }

        public override string Name
        {
            get { return string.Format("Controller Time({0}/{1})", ControllerAction, ControllerName); }
        }

        public override string Description
        {
            get { return string.Format("Time taken to perform the {0} action in the {1} controller", ControllerAction, ControllerName); }
        }

        public override double Value
        {
            get { return iValue; }
        }

        public override bool IsValid()
        {
            return true;
        }
    }   
}
