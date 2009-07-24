using System;
using System.Diagnostics;
using System.Threading;
using System.Web.Mvc;
using Pulse.Emmiters.DotNet.Core.Measurments.MVC;

namespace Pulse.Emmiters.DotNet.Domain.MVC
{
    public class PulseAttribute : ActionFilterAttribute
    {
        private string _controllerAction;
        private string _controllerName;
        private Stopwatch sw;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(state =>
                                                     {
                                                         PulseManager.Push(
                                                             new ControllerTimeMeasurement(_controllerName,
                                                                                           _controllerAction,
                                                                                           (double)
                                                                                           sw.ElapsedMilliseconds), null);
                                                         PulseManager.PushFor("per_mvc_action_request", null);
                                                     });
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                sw.Stop();
            }
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            sw = new Stopwatch();
            sw.Start();
            _controllerAction = filterContext.ActionDescriptor.ActionName;
            _controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            base.OnActionExecuting(filterContext);
        }
    }
}