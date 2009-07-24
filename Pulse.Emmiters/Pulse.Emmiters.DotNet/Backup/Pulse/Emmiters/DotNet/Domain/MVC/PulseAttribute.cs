namespace Pulse.Emmiters.DotNet.Domain.MVC
{
    using Pulse.Emmiters.DotNet;
    using Pulse.Emmiters.DotNet.Core.Measurments.MVC;
    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Web.Mvc;

    public class PulseAttribute : ActionFilterAttribute
    {
        private string controllerAction;
        private string controllerName;
        private Stopwatch sw;

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            try
            {
                try
                {
                    ThreadPool.QueueUserWorkItem(delegate (object c) {
                        PulseManager.Push(new ControllerTimeMeasurement(this.controllerName, this.controllerAction, (double) this.sw.ElapsedMilliseconds), null);
                        PulseManager.PushFor("per_mvc_action_request", null);
                    });
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                this.sw.Stop();
            }
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            this.sw = new Stopwatch();
            this.sw.Start();
            this.controllerAction = filterContext.get_ActionDescriptor().get_ActionName();
            this.controllerName = filterContext.get_ActionDescriptor().get_ControllerDescriptor().get_ControllerName();
            base.OnActionExecuting(filterContext);
        }
    }
}

