using System.Web;
using System.Web.Mvc;
using TP.Mvc.Web.Filters;

namespace TP.Mvc.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionFilter());

        }
    }
}
