using System.Configuration;

namespace Auction.Web.Helpers
{
    public class WebConfigHelper
    {
        public static string ApplicationName {
            get { return GetByKey("appName"); }
        }

        public static string GetByKey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}