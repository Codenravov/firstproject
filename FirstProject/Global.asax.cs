namespace MVCWebProject
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using MVCWebProject.Utilities;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Register();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
