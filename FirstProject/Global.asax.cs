namespace MVCWebProject
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using MVCWebProject.Utilities;
    using MVCWebProjectBLL.Utilities;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfigPL.Register();
            AutofacConfigBLL.Register();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
