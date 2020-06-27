using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreWebUI.Helpers
{
    public static class CacheHelper
    {
        public static string SomeData
        {
            get
            {
                string someData = string.Empty;
                Startup._memoryCache.TryGetValue(CacheKeys.SomeData, out someData);
                return someData;
            }
            set
            {
                var opts = new MemoryCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromHours(1)
                };

                Startup._memoryCache.Set(CacheKeys.SomeData, value, opts);

            }

        }

        public static void ClearCache()
        {
            Startup._memoryCache.Remove(CacheKeys.SomeData);
        }

    }
}
