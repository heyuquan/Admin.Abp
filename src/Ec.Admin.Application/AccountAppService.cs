using Ec.Admin.AggregateRoot;
using Ec.Admin.DTO;
using Ec.Admin.Service;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;

namespace Ec.Admin
{

    // 另一个可以直接操作数据的基类 AsyncCrudAppService


    // [RemoteService(false)]
    // 可以阻止 IRemoteService 接口自动生成 如 /api/app/account/user 的动态接口，swagger UI上会体现
    [RemoteService(false)]
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        private readonly IAccountManager _accountManager;
        private readonly IDistributedCache<MyCacheItem> _cache;
        private readonly IDistributedCache _cache2;
        private IMemoryCache _cache3;

        public AccountAppService(
            IAccountManager accountManager
            , IDistributedCache<MyCacheItem> cache
            , IDistributedCache cache2
            , IMemoryCache cache3
            )
        {
            _accountManager = accountManager;
            _cache = cache;
            _cache2 = cache2;
            _cache3 = cache3;
        }

        public async Task<UserInfoDto> CreateUser(UserCreateDto userCreateDto)
        {
            await _cache.SetAsync("key1", new MyCacheItem { a = "123" }, new DistributedCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddHours(1) });
            await _cache2.SetStringAsync("key2", "value2", new DistributedCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddHours(1) });
            _cache3.Set("key3", "value3");

            var a1 = await _cache.GetAsync("key1");
            var a2 = await _cache2.GetStringAsync("key2");
            var a3 = _cache3.Get("key3");

            var result = await _accountManager.CreateUserInfo(userCreateDto.UserName, userCreateDto.Email, userCreateDto.RoleId);
            return ObjectMapper.Map<UserInfo, UserInfoDto>(result);
        }

        public async Task<bool> DeleteRoleByName(string name)
        {
            return await _accountManager.DeleteRoleByName(name);
        }

        public async Task<RoleDto> CreateRole(RoleCreateDto userCreateDto)
        {
            var result = await _accountManager.CreateRole(userCreateDto.Name);
            return ObjectMapper.Map<Role, RoleDto>(result);
        }
    }
}
