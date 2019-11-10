using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Admin.Abp.Application.Contracts;
using Admin.Abp.Application.Contracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Abp.HttpApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
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