using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Caching;

namespace Ec.Admin.HttpApi.Controllers
{
    [Route("api/abp/redis")]
    public class AbpRedisController : AbpController
    {
        // volo.apb.cache key 默认命名为：c:System.String,k:Ec.Admin:abp.key1 
        // 可重写 NormalizeKey 方法进行调整
        private IDistributedCache<string> cache;

        public AbpRedisController(IDistributedCache<string> cache)
        {
            this.cache = cache;
        }

        [HttpPost]
        [Route("set/string")]
        public async Task<bool> SetString(string key, string value)
        {
            TimeSpan timeout = new TimeSpan(0, 5, 0);
            await cache.SetAsync(key, value,new DistributedCacheEntryOptions { SlidingExpiration = timeout });
            return true;
        }

        [HttpPost]
        [Route("get/string")]
        public async Task<string> GetString(string key)
        {
            return await cache.GetAsync(key);
        }
    }
}