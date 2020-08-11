using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorkflowWeb.Attributes
{
    public class HandleParameters : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var values = filterContext.RouteData.Values;
            var qs = filterContext.RequestContext.HttpContext.Request.QueryString;

            try { filterContext.Controller.ViewBag.HtmlTarget = qs["html_target"]; }
            catch { }

        }
    }
}