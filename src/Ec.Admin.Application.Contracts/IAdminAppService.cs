using Ec.Admin.Application.Contracts.DTO;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Ec.Admin.Application.Contracts
{
    public interface IAdminAppService: IApplicationService
    {
        Task<bool> CreateUser(UserInfoDto userInfoDto);
    }
}
