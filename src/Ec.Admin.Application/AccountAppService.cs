using Ec.Admin.Application.Contracts;
using Ec.Admin.Application.Contracts.DTO;
using Ec.Admin.Domain;
using Ec.Admin.Domain.AggregateRoot;
using Ec.Admin.Domain.Service;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace Ec.Admin.Application
{
    // [RemoteService(false)]
    // 可以阻止 IRemoteService 接口自动生成 如 /api/app/account/user 的动态接口，swagger UI上会体现
    [RemoteService(false)]
    public class AccountAppService : ApplicationService, IAccountAppService
    {
        private readonly IAccountManager _accountManager;

        public AccountAppService(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        public async Task<UserInfoDto> CreateUser(UserCreateDto userCreateDto)
        {
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
