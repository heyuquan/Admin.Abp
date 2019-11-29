using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ec.Admin.Application.Contracts;
using Ec.Admin.Application.Contracts.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ec.Admin.HttpApi.Controllers
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