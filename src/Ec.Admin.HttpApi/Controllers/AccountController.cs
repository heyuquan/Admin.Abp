using Ec.Admin.Application.Contracts;
using Ec.Admin.Application.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Ec.Admin.HttpApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : AbpController
    {
        private readonly IAccountAppService _accountAppService;

        public AccountController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }

        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "hello UserInfoController";
        }

        [HttpPost]
        [Route("user/create")]
        public async Task<UserInfoDto> Create(AccountUserCreateDto userCreateDto)
        {
            return await _accountAppService.CreateUser(userCreateDto);
        }

        [HttpPost]
        [Route("role/delete")]
        public async Task<bool> DeleteRoleByName(string name)
        {
            return await _accountAppService.DeleteRoleByName(name);
        }
    }
}