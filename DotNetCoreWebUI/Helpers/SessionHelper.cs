using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Text;

namespace DotNetCoreWebUI.Helpers
{
    public static class SessionHelper
    {
        public static void Set(this HttpContext HttpContext, string key, string value)
        {
            HttpContext.Session.Set(key, Encoding.UTF8.GetBytes(value));
        }

        public static string Get(this HttpContext HttpContext, string key)
        {
            var bytes = default(byte[]);
            HttpContext.Session.TryGetValue(key, out bytes);
            return Encoding.UTF8.GetString(bytes);
        }

        public static void ClearSession(this HttpContext HttpContext)
        {
            HttpContext.Session.Clear();
        }
    }
}
