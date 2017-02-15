using System.Web;
using System.Web.Mvc;

namespace F16_ST3P3Opgave
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
