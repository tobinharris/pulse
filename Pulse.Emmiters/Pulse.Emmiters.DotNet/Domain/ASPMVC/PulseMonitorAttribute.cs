using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Pulse.Emmiters.DotNet.Domain.ASPMVC
{
    public class PulseMonitorAttribute : ActionFilterAttribute
    {
        public string Action { get; set; }
        public Type Controller { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}
