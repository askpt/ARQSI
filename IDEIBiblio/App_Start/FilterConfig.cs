using System.Web;
using System.Web.Mvc;

namespace IDEIBiblio
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // adding new filter to require authorize attribute in the entire app
            filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }
    }
}
