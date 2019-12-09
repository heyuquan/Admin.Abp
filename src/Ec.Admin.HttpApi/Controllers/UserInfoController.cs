using Ec.Admin.Application.Contracts;
using Ec.Admin.Application.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Ec.Admin.HttpApi.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class UserInfoController : AbpController
    {
        private readonly IAdminAppService _adminAppService;

        public UserInfoController(IAdminAppService adminAppService)
        {
            _adminAppService = adminAppService;
        }

        public async Task<bool> Create(UserInfoDto userInfoDto)
        {
            return await _adminAppService.CreateUser(userInfoDto);
        }
    }
}