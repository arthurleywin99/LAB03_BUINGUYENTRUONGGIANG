using System.Web;
using System.Web.Mvc;

namespace LAB03_BUINGUYENTRUONGGIANG
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
