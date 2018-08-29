using System.Web.Mvc;
using MVCWebProject.ViewModels;

namespace MVCWebProject.Infrastructure
{
    public class ControllerExceptionsAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = new ViewResult { ViewName = "~/Views/Exceptions/Exception.cshtml" };
            ExceptionViewModel model = new ExceptionViewModel();
            model.Action = context.RouteData.Values["action"].ToString();
            model.Exception = context.Exception.ToString();
            model.Message = context.Exception.Message.ToString();
            result.ViewData.Model = model;
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}