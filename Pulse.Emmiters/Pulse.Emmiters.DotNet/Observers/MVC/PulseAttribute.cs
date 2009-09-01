using System.Diagnostics;
using System.Threading;
using System.Web.Mvc;
using Newtonsoft.Json;
using Pulse.Domain;

namespace Pulse.Observers.MVC
{
    public class PulseAttribute : ActionFilterAttribute
    {
        private string _controllerAction;
        private string _controllerName;
        private Stopwatch _sw;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var context = new ObserverContext
                  {
                      {"ControllerName", _controllerName},
                      {"ControllerAction", _controllerAction}
                  };
            try{
                ThreadPool.QueueUserWorkItem(state =>
                {
                    var glue = new ControllerTimeMeasurement(_controllerName, _controllerAction, _sw.ElapsedMilliseconds);
                    PulseManager.Push(glue, null);
                    PulseManager.PushFor("per_mvc_action_request", glue, context);
                });
            }
            catch{
                //TODO: Handle gracefully i.e. log and restart
            }
            finally{
                _sw.Stop();
            }
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _sw = new Stopwatch();
            _sw.Start();
            _controllerAction = filterContext.ActionDescriptor.ActionName;
            _controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            base.OnActionExecuting(filterContext);
        }
    }
}

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