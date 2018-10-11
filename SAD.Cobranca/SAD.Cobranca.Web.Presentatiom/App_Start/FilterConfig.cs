using System.Web;
using System.Web.Mvc;

namespace SAD.Cobranca.Web.Presentatiom
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
