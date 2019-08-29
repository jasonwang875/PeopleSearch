using System.Web;
using System.Web.Mvc;

namespace Web_API
{/// <summary>
/// Filterconfig
/// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Register necessary filters
        /// </summary>
        /// <param name="filters"></param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
