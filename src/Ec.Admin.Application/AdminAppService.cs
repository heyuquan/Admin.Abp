using Ec.Admin.Application.Contracts;
using Ec.Admin.Application.Contracts.DTO;
using Ec.Admin.Domain;
using Ec.Admin.Domain.Service;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Ec.Admin.Application
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
