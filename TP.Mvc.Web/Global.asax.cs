using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace TP.Mvc.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        //添加Elmah日志记录过滤器
        void ErrorLog_Filtering(object sender,Elmah.ExceptionFilterEventArgs e)
        {
            var exception = e.Exception.GetBaseException();
            if (exception is HttpRequestValidationException)
            {
                e.Dismiss();
            }
        }
        void ErrorEmail_Filtering(object sender, Elmah.ExceptionFilterEventArgs e)
        {
            var exception = e.Exception.GetBaseException();
            var httpException = (HttpException)e.Exception;
            if (httpException != null && httpException.GetHttpCode() == 404)
            {
                e.Dismiss();
            }
            if (exception is System.IO.FileNotFoundException || exception is HttpRequestValidationException || exception is HttpException)
            {
                e.Dismiss();
            }
        }
    }
}
