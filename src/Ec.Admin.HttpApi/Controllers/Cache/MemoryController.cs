using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Ec.Admin.Controllers.Cache
{
    [Route("api/memorycache")]
    public class MemoryController : AbpController
    {
        private IMemoryCache cache;

        public MemoryController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [HttpPost]
        [Route("set/string")]
        public async Task<bool> SetString(string key, string value)
        {
            TimeSpan timeout = new TimeSpan(0, 5, 0);
            cache.Set<string>(key, value, new MemoryCacheEntryOptions { SlidingExpiration = timeout });
            return await Task.FromResult<bool>(true);
        }

        [HttpPost]
        [Route("get/string")]
        public string GetString(string key)
        {
            return cache.Get<string>(key);
        }
    }
}