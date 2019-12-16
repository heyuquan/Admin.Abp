using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Ec.Admin.HttpApi.Controllers
{
    [Route("api/redis")]
    public class RedisController : AbpController
    {
        private IDistributedCache cache;

        public RedisController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        [HttpPost]
        [Route("set/string")]
        public async Task<bool> SetString(string key, string value)
        {
            TimeSpan timeout = new TimeSpan(0, 5, 0);
            await cache.SetStringAsync(key, value, new DistributedCacheEntryOptions { SlidingExpiration = timeout });
            return true;
        }

        [HttpPost]
        [Route("get/string")]
        public async Task<string> GetString(string key)
        {
            return await cache.GetStringAsync(key);
        }
    }
}