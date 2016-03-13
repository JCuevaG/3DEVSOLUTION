using _3DEV.MVC.Filters;
using System.Web.Http;

namespace _3DEV.MVC
{
    public class CustomGlobalConfig
    {
        public static void Customize(HttpConfiguration config)
        {
            config.Filters.Add(new ValidationActionFilter());
        }
    }
}