using log4net;
using System.Web.Mvc;
using System;

namespace WebDeveloper.Filters
{
    public class ExceptionControl: ActionFilterAttribute, IExceptionFilter
    {
        private static ILog Log { get; set; }
        ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            log.Error(filterContext.Exception);
            var controllerName = filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"].ToString();
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml",
                MasterName = "~/Views/Shared/_Layout.cshtml",
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
        }
    }
}


    