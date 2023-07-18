using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomaston
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
