using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace masood_lab.Filters
{
    public class AuthorizedUser : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["IsLogin"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary 
                {
                    {"Area", ""},
                    {"Controller", "Home"},
                    {"Action", "Index"}
                });

            }
            base.OnActionExecuting(filterContext);
        }
    }
}