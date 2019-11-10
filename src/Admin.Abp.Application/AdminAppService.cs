using Admin.Abp.Application.Contracts;
using Admin.Abp.Application.Contracts.DTO;
using Admin.Abp.Domain;
using Admin.Abp.Domain.Service;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Sky.Abp.Application
{
    public class AdminAppService : ApplicationService, IAdminAppService
    {
        private readonly IUserManager _userManager;

        public AdminAppService(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CreateUser(UserInfoDto userInfoDto)
        {
            var info = ObjectMapper.Map<UserInfoDto, UserInfo>(userInfoDto);
            var result = await _userManager.CreateUserInfo(info.Name, info.Email);
            return result != null;
        }
    }
}
