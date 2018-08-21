using System.Web.Mvc;

namespace MVCWebProject.Infrastructure
{
    public class ControllerExceptionsAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName = "~/Views/Exceptions/Exception.cshtml" };
            result.ViewData.Add("Action", "Action:" + " " + context.RouteData.Values["action"]);
            result.ViewData.Add("Exception", "Exception:" + " " + context.Exception);
            result.ViewData.Add("Message", "Exception message:" + " " + context.Exception.Message);
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}