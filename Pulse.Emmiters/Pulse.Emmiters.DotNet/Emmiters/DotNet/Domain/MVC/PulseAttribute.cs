using System;
using System.Diagnostics;
using System.Threading;
using System.Web.Mvc;
using Pulse.Emmiters.DotNet.Core.CustomMeasurments;

namespace Pulse.Emmiters.DotNet.Domain.MVC
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

            try
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(state =>
                                                     {
                                                         var glue = new ControllerTimeMeasurement(_controllerName,_controllerAction,_sw.ElapsedMilliseconds);
                                                         PulseManager.Push(glue, null);
                                                         PulseManager.PushFor("per_mvc_action_request", glue, context);
                                                     });
                }
                catch (Exception)
                {
                }
            }
            finally
            {
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