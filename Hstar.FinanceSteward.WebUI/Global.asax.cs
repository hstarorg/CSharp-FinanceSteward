using Hstar.Framework.Ioc;
using Hstar.Framework.Log;
using System.IO;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hstar.FinanceSteward.WebUI
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            //处理视图引擎
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //系统其他初始化
            var configRootPath = Server.MapPath("~/Config/");
            //IOC
            AutofacHelper.InitAutofacContainer(Path.Combine(configRootPath, "Autofac/AutofacConfig.xml"));
            //日志
            Log4NetHelper.InitLog4Net(Path.Combine(configRootPath, "Log4net/Log4Net.xml"));
        }
    }
}